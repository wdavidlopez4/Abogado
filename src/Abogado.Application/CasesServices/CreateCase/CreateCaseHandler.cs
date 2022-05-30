
using Abogado.Domain.Entities;
using Abogado.Domain.Ports;
using Ardalis.GuardClauses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Abogado.Application.CasesServices.CreateCase
{
    public class CreateCaseHandler : IRequestHandler<CreateCaseCommand, int>
    {
        private readonly IRepository repository;

        private readonly IRepositoryDocument repositoryDocumnet;

        public CreateCaseHandler(IRepository repository, IRepositoryDocument repositoryDocumnet)
        {
            this.repository = repository;
            this.repositoryDocumnet = repositoryDocumnet;
        }

        public async Task<int> Handle(CreateCaseCommand request, CancellationToken cancellationToken)
        {
            Case caseAux;
            User user;
            FileDocument document;
            string ruta;

            //Verificar que la peticion no este nula
            Guard.Against.Null(request, nameof(request));

            //subimos, guardamos y creamos el archivo
            //ruta = await repositoryDocumnet.SubirArchivo(request.Archivo);
            //document = FileDocument.Build(filePath: ruta);
            //await repository.Save<FileDocument>(document);

            //Crear caso y gurdamos
            caseAux = Case.Build(
                 caseName: request.CaseName,
                 description: request.Description,
                 trial: request.Trial,
                 divorceForm: request.DivorceForm,
                 divorceMechanism: request.DivorceMechanism,
                 fileId: Guid.Parse("6019353c-2604-414d-a90f-c437066b558e"),
                 startDate: request.StartDate);

            if (repository.Exists<User>(x => x.Id.ToString() == request.LawyerId) is false)
                throw new Exception("El usuario no existe");

            user = await repository.Get<User>(x => x.Id.ToString() == request.LawyerId);

            caseAux.AddUser(user);

            //comitiamos y retornamos
            await repository.Save<Case>(caseAux);
            await repository.Commit();
            return 0;
        }
    }
}
