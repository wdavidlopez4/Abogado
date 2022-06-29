using Abogado.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Abogado.Web.Models
{
    public class RegisterCaseVM
    {
        [RegularExpression("[A-Za-z0-9]+", ErrorMessage = "* .. solo letras")]
        public string CaseName { get; set; }

        [RegularExpression("[A-Za-z0-9]+", ErrorMessage = "* .. solo letras")]
        public string Description { get; set; }

        public Proceso Trial { get; set; }

        public DivorceForm DivorceForm { get; set; }

        public DivorceMechanism DivorceMechanism { get; set; }

        public IFormCollection Archivo { get; set; }

        public DateTime StartDate { get; set; }
    }
}
