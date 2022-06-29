using Abogado.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Abogado.Web.Models
{
    public class RegisterUserVM
    {
        public Role Role { get; set; }

        [RegularExpression("[A-Za-z0-9]+", ErrorMessage = "* .. solo letras")]
        public string Name { get; set; }

        [RegularExpression("[A-Za-z0-9]+", ErrorMessage = "* .. solo letras")]
        public string LastName { get; set; }

        public string Mail { get; set; }

        public string Password { get; set; }
    }
}
