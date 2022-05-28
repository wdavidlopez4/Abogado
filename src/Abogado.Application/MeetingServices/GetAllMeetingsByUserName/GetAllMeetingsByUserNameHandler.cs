using Abogado.Application.MeetingServices.GetAllMeetingsByUserId;
using Abogado.Domain.Entities;
using Abogado.Domain.Ports;
using Ardalis.GuardClauses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.MeetingServices.GetAllMeetingsByUserName
{
    public class GetAllMeetingsByUserNameHandler : IRequestHandler<GetAllMeetingsByUserNameQuery, List<GetAllMeetingsByUserNameDTO>>
    {

        private readonly IRepository repository;

        private readonly IMapObject mapObject;

        public GetAllMeetingsByUserNameHandler(IRepository repository, IMapObject mapObject)
        {
            this.repository = repository;
            this.mapObject = mapObject;
        }

        public async Task<List<GetAllMeetingsByUserNameDTO>> Handle(GetAllMeetingsByUserNameQuery request, CancellationToken cancellationToken)
        {
            List<UserMeeting> meetingsUser = new();

            //Verificar que la peticion no este nula
            Guard.Against.Null(request, nameof(request));

            //Obtener usuario 
            if (!string.IsNullOrEmpty(request.Name))
            {
                meetingsUser = await repository.GetAllNested<UserMeeting>(x => x.User.Name.Contains(request.Name), nameof(UserMeeting.User), nameof(UserMeeting.Meeting));
            }

            //Mapear objeto y retonar
            return mapObject.Map<List<UserMeeting>, List<GetAllMeetingsByUserNameDTO>>(meetingsUser);
        }
    }
}
