using Abogado.Application.MeetingServices.GetAllMeetingsByUserId;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.MeetingServices.GetAllMeetingsByUserName
{
    public class GetAllMeetingsByUserNameQuery: IRequest<List<GetCaseByUserDTO>>
    {
        public string Name { get; set; }
    }
}
