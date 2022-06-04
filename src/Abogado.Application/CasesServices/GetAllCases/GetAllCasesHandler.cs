using Abogado.Domain.Entities;
using Abogado.Domain.Ports;
using Ardalis.GuardClauses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.CasesServices.GetAllCases
{
    public class GetAllCasesHandler : IRequestHandler<GetAllCasesQuery, List<GetAllCasesDTO>>
    {

        private readonly IRepository repository;

        private readonly IMapObject mapObject;

        public GetAllCasesHandler(IRepository repository, IMapObject mapObject)
        {
            this.repository = repository;
            this.mapObject = mapObject;
        }

        public async Task<List<GetAllCasesDTO>> Handle(GetAllCasesQuery request, CancellationToken cancellationToken)
        {
            List<Case> cases;

            //Verificar que la peticion no este nula
            Guard.Against.Null(request, nameof(request));

            //Obtener todos los casos
            cases = await repository.GetAllNested<Case>(x => x.IsPrincipalCase, nameof(Case.Users), nameof(Case.File), nameof(Case.CaseHistory));

            //Mapear y retornar
            return mapObject.Map<List<Case>, List<GetAllCasesDTO>>(cases);
        }
    }
}
