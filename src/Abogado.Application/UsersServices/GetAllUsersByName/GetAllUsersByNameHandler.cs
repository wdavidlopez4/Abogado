using Abogado.Domain.Entities;
using Abogado.Domain.Ports;
using Ardalis.GuardClauses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.UsersServices.GetAllUsersByName
{
    public class GetAllUsersByNameHandler : IRequestHandler<GetAllUsersByNameQuery, List<GetAllUsersByNameDTO>>
    {
        private readonly IRepository repository;
        private readonly IMapObject mapObject;

        public GetAllUsersByNameHandler(IRepository repository, IMapObject mapObject)
        {
            this.repository = repository;
            this.mapObject = mapObject;
        }

        public async Task<List<GetAllUsersByNameDTO>> Handle(GetAllUsersByNameQuery request, CancellationToken cancellationToken)
        {
            List<User> users;

            //Verificar que la peticion no se encuentre nula
            Guard.Against.Null(request, nameof(request));

            string[] name = request.FilterName.Split(" ");

            //Obtener los usuario por nombre
            users = await repository.GetAllNested<User>(x => x.Name.Contains(name.First()) || x.Lastname.Contains(name.Last()) ,nameof(User.Meetings), nameof(User.Cases));

            //Mapear objeto y retornar
            return mapObject.Map<List<User>, List<GetAllUsersByNameDTO>>(users);
        }
    }
}
