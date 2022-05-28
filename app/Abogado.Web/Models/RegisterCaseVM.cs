using Abogado.Domain.Enums;

namespace Abogado.Web.Models
{
    public class RegisterCaseVM
    {
        public string CaseName { get; set; }

        public string Description { get; set; }

        public Trial Trial { get; set; }

        public DivorceForm DivorceForm { get; set; }

        public DivorceMechanism DivorceMechanism { get; set; }

        public IFormFile Archivo { get; set; }

        public DateTime StartDate { get; set; }
    }
}
