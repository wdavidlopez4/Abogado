using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.MeetingServices.ModifyMeeting
{
    public class ModifyMeetingCommand : IRequest<int>
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
    }
}
