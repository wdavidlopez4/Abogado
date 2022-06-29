using Abogado.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Abogado.Web.Models
{
    public class EditUserVM
    {
        public string UserId { get; set; }

        [RegularExpression("[A-Za-z0-9]+", ErrorMessage = "* .. solo letras")]
        public string Name { get; set; }

        [RegularExpression("[A-Za-z0-9]+", ErrorMessage = "* .. solo letras")]
        public string Lastname { get; set; }

        [RegularExpression("[A-Za-z0-9]+", ErrorMessage = "* .. solo letras")]
        public string Email { get; set; }

        [RegularExpression("[A-Za-z0-9]+", ErrorMessage = "* .. solo letras")]
        public string Password { get; set; }
    }
}
