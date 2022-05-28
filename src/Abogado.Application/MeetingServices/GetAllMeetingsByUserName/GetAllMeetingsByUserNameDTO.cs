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
        public MeetingDTO Meeting { get; set; }

        public UserDTO User { get; set; }

        public class MeetingDTO
        {
            public string Id { get; set; }

            public DateTime Date { get; set; }
        }

        public class UserDTO
        {
            public Role Role { get; private set; }

            public string Name { get; private set; }

            public string Lastname { get; private set; }

            public string Email { get; private set; }
        }
    }
}
