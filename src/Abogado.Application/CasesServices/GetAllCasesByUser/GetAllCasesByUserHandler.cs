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

            //Verificar que las 2 peticiones no esten vacias o nulas
            if (string.IsNullOrEmpty(request.Id) && string.IsNullOrEmpty(request.NameUser))
                throw new Exception("Los campos se encuentran vacios");

            //Obtener usuario 
            if ((!string.IsNullOrEmpty(request.Id)) && repository.Exists<Case>(x => x.Id.ToString() == request.Id))
            {
                cases.Add(await repository.GetNested<Case>(x => x.Id.ToString() == request.Id, nameof(Case.Users)));
            }
            else if (!string.IsNullOrEmpty(request.NameUser))
            {
                ///Falta comprobrar si asocia directamente el usuario
                //cases = await repository.GetAllNested<Case>(x => x.Users.Any((x) => x.Name.Contains(request.NameUser)), nameof(Case.Users));
            }

            //Mapear y retornar entidad
            return mapObject.Map<List<Case>, List<GetAllCasesByUserDTO>>(cases);
        }
    }
}
