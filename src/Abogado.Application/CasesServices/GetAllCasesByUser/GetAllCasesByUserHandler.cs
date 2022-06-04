using Abogado.Domain.Entities;
using Abogado.Domain.Ports;
using Ardalis.GuardClauses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.CasesServices.GetAllCasesByUser
{
    public class GetAllCasesByUserHandler : IRequestHandler<GetAllCasesByUserQuery, List<GetAllCasesByUserDTO>>
    {
        private readonly IRepository repository;

        private readonly IMapObject mapObject;

        public GetAllCasesByUserHandler(IRepository repository, IMapObject mapObject)
        {
            this.repository = repository;
            this.mapObject = mapObject;
        }

        public async Task<List<GetAllCasesByUserDTO>> Handle(GetAllCasesByUserQuery request, CancellationToken cancellationToken)
        {

            List<Case> cases = new();

            //Verificar que la peticion no se encuentre nula
            Guard.Against.Null(request, nameof(request));

            cases = await repository.GetAllNested<Case>(x => x.CaseName.Contains(request.NameCase) && x.IsPrincipalCase == true, nameof(Case.Users), nameof(File));

            //Mapear y retornar entidad
            return mapObject.Map<List<Case>, List<GetAllCasesByUserDTO>>(cases);
        }
    }
}
