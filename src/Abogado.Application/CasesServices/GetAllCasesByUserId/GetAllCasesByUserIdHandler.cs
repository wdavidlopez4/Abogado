using Abogado.Domain.Entities;
using Abogado.Domain.Ports;
using Ardalis.GuardClauses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.CasesServices.GetAllCasesByUserId
{
    public class GetAllCasesByUserIdHandler : IRequestHandler<GetAllCasesByUserIdQuery, List<GetAllCasesByUserIdDTO>>
    {
        private readonly IRepository repository;

        private readonly IMapObject mapObject;

        public GetAllCasesByUserIdHandler(IRepository repository, IMapObject mapObject)
        {
            this.repository = repository;
            this.mapObject = mapObject;

        }

        public async Task<List<GetAllCasesByUserIdDTO>> Handle(GetAllCasesByUserIdQuery request, CancellationToken cancellationToken)
        {
            List<Case> caseAux;

            Guard.Against.Null(request, nameof(request));

            caseAux = await repository.GetAllNested<Case>(x => x.Users.Any(x => x.Id.ToString() == request.UserId) && x.IsPrincipalCase, nameof(Case.Users), nameof(File));

            return mapObject.Map<List<Case>, List<GetAllCasesByUserIdDTO>>(caseAux);

        }
    }
}
