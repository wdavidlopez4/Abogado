using Abogado.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.CasesServices.GetByCaseId
{
    public class GetByCaseIdDTO
    {
        public string Id { get; set; }

        public List<UserCaseDTO> Users { get; set; }

        public List<GetByCaseIdDTO> CaseHistory { get; set; }

        public string CaseName { get; set; }

        public string Description { get; set; }

        public Trial Trial { get; set; }

        public DivorceForm DivorceForm { get; set; }

        public DivorceMechanism DivorceMechanism { get; set; }

        public Guid FileId { get; set; }

        public DateTime StartDate { get; set; }

        public class UserCaseDTO
        {
            public Guid UserId { get; set; }
        }

    }
}
