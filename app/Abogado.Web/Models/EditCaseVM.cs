using Abogado.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Abogado.Web.Models
{
    public class EditCaseVM
    {
        public string Id { get; set; }

        [RegularExpression("[A-Za-z0-9]+", ErrorMessage = "* .. solo letras")]
        public string CaseName { get; set; }

        [RegularExpression("[A-Za-z0-9]+", ErrorMessage = "* .. solo letras")]
        public string Description { get; set; }

        public Proceso Trial { get; set; }

        public DivorceMechanism DivorceMechanism { get; set; }

        public DivorceForm DivorceForm  { get; set; }

        public IFormFile Archivo { get; set; }

        public bool IsSave { get; set; }
    }
}
