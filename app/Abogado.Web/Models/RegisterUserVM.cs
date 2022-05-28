using Abogado.Domain.Enums;

namespace Abogado.Web.Models
{
    public class RegisterUserVM
    {
        public Role Role { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Mail { get; set; }

        public string Password { get; set; }
    }
}
