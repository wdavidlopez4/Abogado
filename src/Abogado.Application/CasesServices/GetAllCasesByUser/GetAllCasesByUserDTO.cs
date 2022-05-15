using Abogado.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.CasesServices.GetAllCasesByUser
{
    public class GetAllCasesByUserDTO
    {
        public List<CaseDTO> Cases { get; }

        public Role Role { get; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public class CaseDTO
        {
            public string CaseName { get; private set; }

            public string Description { get; private set; }

            public Trial Trial { get; }

            public DivorceForm DivorceForm { get; }

            public DivorceMechanism DivorceMechanism { get; }

            public Guid FileId { get; }

            public DateTime StartDate { get; }
        }
    }
}
