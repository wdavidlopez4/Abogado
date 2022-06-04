using Abogado.Domain.Enums;

namespace Abogado.Web.Models
{
    public class EditCaseVM
    {
        public string Id { get; set; }

        public string CaseName { get; set; }

        public string Description { get; set; }

        public Trial Trial { get; set; }

        public DivorceMechanism DivorceMechanism { get; set; }

        public DivorceForm DivorceForm  { get; set; }

        public IFormFile Archivo { get; set; }

        public bool IsSave { get; set; }
    }
}
