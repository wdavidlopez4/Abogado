using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.MeetingServices.AssignUser
{
    public class AssignUserCommand : IRequest<int>
    {
        public string UserId { get; set; }

        public string MeetingId { get; set; }
    }
}
