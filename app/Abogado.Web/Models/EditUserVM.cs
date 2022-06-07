using Abogado.Domain.Enums;

namespace Abogado.Web.Models
{
    public class EditUserVM
    {
        public string UserId { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
