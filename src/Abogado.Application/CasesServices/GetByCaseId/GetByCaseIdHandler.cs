using Abogado.Domain.Entities;
using Abogado.Domain.Ports;
using Ardalis.GuardClauses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.CasesServices.GetByCaseId
{
    public class GetByCaseIdHandler : IRequestHandler<GetByCaseIdQuery, GetByCaseIdDTO>
    {
        private readonly IRepository repository;
        private readonly IMapObject mapObject;

        public GetByCaseIdHandler(IRepository repository, IMapObject mapObject)
        {
            this.repository = repository;
            this.mapObject = mapObject;
        }

        public async Task<GetByCaseIdDTO> Handle(GetByCaseIdQuery request, CancellationToken cancellationToken)
        {
            Case caseAux;

            //Verificar que la peticion no este nula
            Guard.Against.Null(request,nameof(request));

            //Verificar que el caso exista, si existe obtenerlo
            if (repository.Exists<Case>(x => x.Id.ToString() == request.Id) is false)
                throw new Exception("El caso no se encuentra registrado");

            caseAux = await repository.GetNested<Case>(x => x.Id.ToString() == request.Id, nameof(Case.CaseHistory), nameof(Case.Users));

            //Mapear entidad y retornar
            return mapObject.Map<Case, GetByCaseIdDTO>(caseAux);
        }

    }
}
