using Abogado.Domain.Entities;
using Abogado.Domain.Ports;
using Ardalis.GuardClauses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.MeetingServices.GetAllMeetingsByUserId
{
    public class GetAllMeetingsByUserIdHandler : IRequestHandler<GetAllMeetingsByUserName, List<GetAllMeetingsByUserIdDTO>>
    {
        private readonly IRepository repository;

        private readonly IMapObject mapObject;

        public GetAllMeetingsByUserIdHandler(IRepository repository, IMapObject mapObject)
        {
            this.repository = repository;
            this.mapObject = mapObject;
        }

        public async Task<List<GetAllMeetingsByUserIdDTO>> Handle(GetAllMeetingsByUserName request, CancellationToken cancellationToken)
        {

            List<UserMeeting> meetingsUsers = new();

            //Verificar que la peticion no este nula
            Guard.Against.Null(request, nameof(request));

            //Obtener usuario 
            if ((!string.IsNullOrEmpty(request.UserId)) && repository.Exists<User>(x => x.Id.ToString() == request.UserId))
            {
                meetingsUsers = await repository.GetAllNested<UserMeeting>(x => x.UserId.ToString() == request.UserId, nameof(UserMeeting.User), nameof(UserMeeting.Meeting));
            }

            //Mapear objeto y retonar
            return mapObject.Map<List<UserMeeting>, List<GetAllMeetingsByUserIdDTO>>(meetingsUsers);

        }

    }
}
