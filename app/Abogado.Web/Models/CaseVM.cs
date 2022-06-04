using Abogado.Domain.Entities;
using Abogado.Domain.Enums;

namespace Abogado.Web.Models
{
    public class CaseVM
    {
        public string Id { get; set; }

        public List<UserDTO> Users { get; set; }

        public List<CaseDTO> CaseHistory { get; set; }

        public string CaseName { get; set; }

        public string Description { get; set; }

        public Trial Trial { get; set; }

        public DivorceForm DivorceForm { get; set; }

        public DivorceMechanism DivorceMechanism { get; set; }

        public string FileId { get; set; }

        public FileDocument File { get; set; }

        public DateTime StartDate { get; set; }

        public class UserDTO
        {

            public string Id { get; set; }

            public Role Role { get; set; }

            public string Name { get; set; }

            public string Lastname { get; set; }

            public string Email { get; set; }

        }

        public class CaseDTO
        {
            public string Id { get; set; }

            public List<UserDTO> Users { get; set; }

            public string CaseName { get; set; }

            public string Description { get; set; }

            public Trial Trial { get; set; }

            public DivorceForm DivorceForm { get; set; }

            public DivorceMechanism DivorceMechanism { get; set; }

            public string FileId { get; set; }

            public DateTime StartDate { get; set; }
        }
    }
}
