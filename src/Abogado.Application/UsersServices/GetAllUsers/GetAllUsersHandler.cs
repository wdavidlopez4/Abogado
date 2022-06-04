using Abogado.Domain.Entities;
using Abogado.Domain.Ports;
using Ardalis.GuardClauses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.UsersServices.GetAllUsers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<GetAllUsersDTO>>
    {
        private readonly IRepository repository;

        private readonly IMapObject mapObject;

        public GetAllUsersHandler(IRepository repository, IMapObject mapObject)
        {
            this.repository = repository;
            this.mapObject = mapObject;
        }

        public async Task<List<GetAllUsersDTO>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            List<User> users;

            //Verificar que la peticion no este nula
            Guard.Against.Null(repository, nameof(repository));

            //Obtener todos los usuarios
            users = await repository.GetAllNested<User>(x => x.Id.ToString() != "0", nameof(User.Meetings));

            //Mapear lista y retornar
            return mapObject.Map<List<User>, List<GetAllUsersDTO>>(users);
        }
    }
}
