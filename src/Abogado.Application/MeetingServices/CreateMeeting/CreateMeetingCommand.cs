using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.MeetingServices.CreateMeeting
{
    public class CreateMeetingCommand : IRequest<int>
    {
        public DateTime Date { get; set; }

    }
}
