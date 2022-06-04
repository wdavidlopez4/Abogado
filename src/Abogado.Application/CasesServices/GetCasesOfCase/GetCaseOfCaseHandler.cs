using Abogado.Domain.Entities;
using Abogado.Domain.Ports;
using Ardalis.GuardClauses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.CasesServices.GetCasesOfCase
{
    public class GetCaseOfCaseHandler : IRequestHandler<GetCasesOfCaseQuery, List<GetCasesOfCaseDTO>>
    {
        private readonly IRepository repository;

        private IMapObject mapObject;

        public GetCaseOfCaseHandler(IRepository repository, IMapObject mapObject)
        {
            this.repository = repository;
            this.mapObject = mapObject;
        }

        public async Task<List<GetCasesOfCaseDTO>> Handle(GetCasesOfCaseQuery request, CancellationToken cancellationToken)
        {

            List<Case> cases;

            //Verificar que la peticion no este nula
            Guard.Against.Null(request, nameof(request));

            cases = await repository.GetAllNested<Case>(x => x.CaseId.ToString() == request.FatherCaseId, nameof(Case.File)) ;

            //Mapear y retornar
            return mapObject.Map<List<Case>, List<GetCasesOfCaseDTO>>(cases);

        }

    }
}
