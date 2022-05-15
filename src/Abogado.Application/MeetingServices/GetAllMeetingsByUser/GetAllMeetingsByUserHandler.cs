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
    public class GetAllMeetingsByUserHandler : IRequestHandler<GetAllMeetingsByUserQuery, List<GetAllMeetingsByUserDTO>>
    {
        private readonly IRepository repository;

        private readonly IMapObject mapObject;

        public GetAllMeetingsByUserHandler(IRepository repository, IMapObject mapObject)
        {
            this.repository = repository;
            this.mapObject = mapObject;
        }

        public async Task<List<GetAllMeetingsByUserDTO>> Handle(GetAllMeetingsByUserQuery request, CancellationToken cancellationToken)
        {
            List<User> users = new();

            //Verificar que la peticion no este nula
            Guard.Against.Null(request, nameof(request));

            //Verificar que las 2 peticiones no esten vacias o nulas
            if (string.IsNullOrEmpty(request.UserId) && string.IsNullOrEmpty(request.UserName))
                throw new Exception("Los campos se encuentran vacios");

            //Obtener usuario 
            if ((!string.IsNullOrEmpty(request.UserId)) && repository.Exists<User>(x => x.Id.ToString() == request.UserId))
            {
                users.Add(await repository.GetNested<User>(x => x.Id.ToString() == request.UserId, nameof(User.Meetings)));
            }
            else if (!string.IsNullOrEmpty(request.UserName))
            {
                users = await repository.GetAllNested<User>(x => x.Name.Contains(request.UserName), nameof(User.Meetings));
            }

            //Mapear objeto y retonar
            return mapObject.Map<List<User>, List<GetAllMeetingsByUserDTO>>(users);

        }

    }
}
