using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.MeetingServices.GetAllMeetingsByUserId
{
    public class GetAllMeetingsByUserName : IRequest<List<GetAllMeetingsByUserIdDTO>>
    {
        public string UserId { get; set; }

    }
}
