using Abogado.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.UsersServices.GetAllUsers
{
    public class GetAllUsersDTO
    {
        public string Id { get; set; }

        public Role Role { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }


        public List<MeetingDTO> Meetings { get; set; }


        public class MeetingDTO
        {
            public string Id { get; set; }

            public DateTime Date { get; set; }
        }
    }
}
