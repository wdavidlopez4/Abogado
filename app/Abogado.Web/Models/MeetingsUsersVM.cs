using Abogado.Domain.Enums;

namespace Abogado.Web.Models
{
    public class MeetingsUsersVM
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
