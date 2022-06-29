using Abogado.Domain.Enums;
using System.ComponentModel.DataAnnotations;

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

            [RegularExpression("[A-Za-z0-9]+", ErrorMessage = "* .. solo letras")]
            public string Name { get; set; }

            [RegularExpression("[A-Za-z0-9]+", ErrorMessage = "* .. solo letras")]
            public string Lastname { get; set; }

            public string Email { get; set; }
        }
    }
}
