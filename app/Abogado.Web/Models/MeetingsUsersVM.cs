using Abogado.Domain.Enums;

namespace Abogado.Web.Models
{
    public class MeetingsUsersVM
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
