using Abogado.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.CasesServices.GetAllCasesByUserId
{
    public class GetAllCasesByUserIdDTO
    {
        public string Id { get; set; }

        public List<UserDTO> Users { get; set; }

        public string CaseName { get; set; }

        public string Description { get; set; }

        public Trial Trial { get; set; }

        public DivorceForm DivorceForm { get; set; }

        public DivorceMechanism DivorceMechanism { get; set; }

        public Guid FileId { get; set; }

        public DateTime StartDate { get; set; }

        public class UserDTO
        {
            public string Id { get; set; }

            public Role Role { get; set; }

            public string Name { get; set; }

            public string Lastname { get; set; }

            public string Email { get; set; }
        }

    }
}
