namespace Abogado.Web.Models
{
    public class EditCaseVM
    {
        public string Id { get; set; }

        public string CaseName { get; set; }

        public string Description { get; set; }

        public IFormFile Archivo { get; set; }

        public bool IsSave { get; set; }
    }
}
