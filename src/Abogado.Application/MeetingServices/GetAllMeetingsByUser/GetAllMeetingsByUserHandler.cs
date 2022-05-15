using Abogado.Domain.Entities;
using Abogado.Domain.Ports;
using Ardalis.GuardClauses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.MeetingServices.GetAllMeetingsByUser
{
    public class GetAllMeetingsByUserHandler : IRequestHandler<GetAllMeetingsByUserQuery, GetAllMeetingsByUserDTO>
    {
        private readonly IRepository repository;

        private readonly IMapObject mapObject;

        public GetAllMeetingsByUserHandler(IRepository repository, IMapObject mapObject)
        {
            this.repository = repository;
            this.mapObject = mapObject;
        }

        public async Task<GetAllMeetingsByUserDTO> Handle(GetAllMeetingsByUserQuery request, CancellationToken cancellationToken)
        {
            User user;

            //Verificar que la peticion no este nula
            Guard.Against.Null(request, nameof(request));

            //verificar si el usuario existe
            if (repository.Exists<User>(x => x.Id.ToString() == request.UserId) is false)
                throw new Exception("El usuario no esta registrado");

            //Obtener el usuario y su lista de citas
            user = await repository.GetNested<User>(x => x.Id.ToString() == request.UserId, nameof(User.Meetings));

            //Mapear objeto y retonar
            return mapObject.Map<User, GetAllMeetingsByUserDTO>(user);

        }

    }
}
