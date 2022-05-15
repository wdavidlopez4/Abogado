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

        public ModifyCaseHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> Handle(ModifyCaseCommand request, CancellationToken cancellationToken)
        {
            Case caseAux;

            //Verificar que la peticion no este nula
            Guard.Against.Null(request, nameof(request));

            //Verificar que exista el caso, si existe obtenerlo
            if (repository.Exists<Case>(x => x.Id.ToString() == request.Id) is false)
                throw new Exception("El caso no se encuentra registrado");

            //Obtener entidad y cambiar atributos
            caseAux = await repository.Get<Case>(x => x.Id.ToString() == request.Id);
            caseAux.ChangeAtributtes(request.CaseName, request.Description);

            //Guardar entidad
            await repository.Update<Case>(caseAux);
            await repository.Commit();

            return 0;
        }

    }
}
