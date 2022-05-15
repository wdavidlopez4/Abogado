using Abogado.Domain.Entities;
using Abogado.Domain.Ports;
using Ardalis.GuardClauses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.UsersServices.GetUserId
{
    public class GetUserIdHandler : IRequestHandler<GetUserIdQuery, GetUserIdDTO>
    {
        private readonly IRepository repository;

        private readonly IMapObject MapObject;

        public GetUserIdHandler(IRepository repository, IMapObject mapObject)
        {
            this.repository = repository;
            MapObject = mapObject;
        }

        public async Task<GetUserIdDTO> Handle(GetUserIdQuery request, CancellationToken cancellationToken)
        {
            User user;

            //Verificar que la peticion no este nula
            Guard.Against.Null(request, nameof(request));

            //Verificar si existe y obtener usuario
            if (repository.Exists<User>(x => x.Id.ToString() == request.Id) is false)
                throw new Exception("El usuario no se encuentra registrado");

            user = await repository.GetNested<User>(x => x.Id.ToString() == request.Id, nameof(User.Cases), nameof(User.Meetings));

            //Mapear objeto y retornar
            return MapObject.Map<User, GetUserIdDTO>(user);
        }
    }
}
