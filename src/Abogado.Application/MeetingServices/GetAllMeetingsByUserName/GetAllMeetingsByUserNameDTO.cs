using Abogado.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.MeetingServices.GetAllMeetingsByUserName
{
    public class GetAllMeetingsByUserNameDTO
    {
        public string Id { get; set; }

        public List<UserDTO> Users { get; set; }

        public DateTime Date { get; set; }

        public class UserDTO
        {
            public string Id { get; set; }

            public Role Role { get; set; }

            public string Name { get; set; }

            public string Lastname { get; set; }

            public string Email { get; set; }
        }
    }
}
