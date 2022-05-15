using Abogado.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.MeetingServices.GetMeetingById
{
    public class GetMeetingByIdDTO
    {
        public DateTime Date { get;  set; }

        public List<UserDTO> Users { get; set; }

        public class UserDTO
        {
            public Role Role { get; }

            public string Name { get; set; }

            public string Lastname { get; set; }

            public string Email { get; set; }
        }
    }
}
