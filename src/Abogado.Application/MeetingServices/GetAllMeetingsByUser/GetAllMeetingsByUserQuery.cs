using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.MeetingServices.GetAllMeetingsByUser
{
    public class GetAllMeetingsByUserQuery: IRequest<List<GetAllMeetingsByUserDTO>>
    {
        public string UserId { get; set; }

        public string UserName { get; set; }
    }
}
