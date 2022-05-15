using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.MeetingServices.GetAllMeetingsByUser
{
    public class GetAllMeetingsByUserQuery: IRequest<GetAllMeetingsByUserDTO>
    {
        public string UserId { get; set; }

    }
}
