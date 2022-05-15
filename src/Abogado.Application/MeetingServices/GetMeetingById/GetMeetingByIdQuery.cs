using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.MeetingServices.GetMeetingById
{
    public class GetMeetingByIdQuery : IRequest<GetMeetingByIdDTO>
    {
       public string Id { get; set; }
    }
}
