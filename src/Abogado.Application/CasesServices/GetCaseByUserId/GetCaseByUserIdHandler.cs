using Abogado.Domain.Entities;
using Abogado.Domain.Ports;
using Ardalis.GuardClauses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.CasesServices.GetCaseByUserId
{
    public class GetCaseByUserIdHandler : IRequestHandler<GetCaseByUserIdQuery, GetCaseByUserIdDTO>
    {
        private readonly IRepository repository;

        private readonly IMapObject mapObject;

        public GetCaseByUserIdHandler(IRepository repository, IMapObject mapObject)
        {
            this.repository = repository;
            this.mapObject = mapObject;
        }

        public async Task<GetCaseByUserIdDTO> Handle(GetCaseByUserIdQuery request, CancellationToken cancellationToken)
        {
            Case caseAux;

            Guard.Against.Null(request, nameof(request));

            if (repository.Exists<User>(x => x.Id.ToString() == request.UserId) is false)
                throw new Exception("El usuario no existe");

            caseAux = await repository.GetNested<Case>(x => x.Users.Any(x => x.Id.ToString() == request.UserId), nameof(Case.Users), nameof(File));

            return mapObject.Map<Case, GetCaseByUserIdDTO>(caseAux);

        }
    }
}
