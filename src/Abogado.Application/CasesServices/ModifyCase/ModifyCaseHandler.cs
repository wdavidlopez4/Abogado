using Abogado.Domain.Entities;
using Abogado.Domain.Ports;
using Ardalis.GuardClauses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.CasesServices.ModifyCase
{
    public class ModifyCaseHandler : IRequestHandler<ModifyCaseCommand, int>
    {
        private readonly IRepository repository;

        private readonly IRepositoryDocument repositoryDocument;

        public ModifyCaseHandler(IRepository repository, IRepositoryDocument repositoryDocumnet)
        {
            this.repository = repository;
            this.repositoryDocument = repositoryDocumnet;
        }

        public async Task<int> Handle(ModifyCaseCommand request, CancellationToken cancellationToken)
        {
            Case caseAux;
            Case caseOld;
            FileDocument document;
            FileDocument newDocument;

            //Verificar que la peticion no este nula
            Guard.Against.Null(request, nameof(request));

            //Verificar que exista el caso, si existe obtenerlo
            if (repository.Exists<Case>(x => x.Id.ToString() == request.Id) is false)
                throw new Exception("El caso no se encuentra registrado");

            //Obtener caso
            caseAux = await repository.GetNested<Case>(x => x.Id.ToString() == request.Id, nameof(Case.Users));

            if (request.IsSave && request.Archivo == null)
            {
                throw new Exception("Si se añade a un historial de cambios se debe cargar un archivo");
            }

            //Si hay un archivo
            if (request.Archivo != null)
            {
                //Crear nuevo archivo
                newDocument = FileDocument.Build(await repositoryDocument.SubirArchivo(request.Archivo));
                await repository.Save<FileDocument>(newDocument);

                //Obtener el documento
                document = await repository.Get<FileDocument>(x => x.Id.ToString() == caseAux.FileId.ToString());

                //Agregar caso al historial de casos si se desea
                if (request.IsSave)
                {
                    caseOld = Case.Build(request.CaseName, request.Description, caseAux.Trial, caseAux.DivorceForm, caseAux.DivorceMechanism, caseAux.FileId, caseAux.StartDate);
                    caseAux.Users.ForEach(x =>
                    {
                        caseOld.AddUser(x);
                    });

                    await repository.Save(caseOld);
                    caseAux.AddCaseHistory(caseOld);
                }
                else
                {
                    repositoryDocument.EliminarArchivo(document.FilePath);

                    //Cambiar atributos
                    caseAux.ChangeAtributtes(request.CaseName, request.Description, newDocument.Id);

                    //Eliminar FileDocument antiguo de la base de datos
                    await repository.Delete<FileDocument>(document);
                }
            }
            else
                caseAux.ChangeAtributtes(request.CaseName, request.Description);

            //Guardar entidad
            await repository.Update<Case>(caseAux);
            await repository.Commit();

            return 0;
        }

    }
}
