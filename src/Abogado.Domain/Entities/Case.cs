using Abogado.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Domain.Entities
{
    public class Case : Entity
    {
        public Guid UserId { get; }

        public User User { get; }

        public User Lawyer { get; }

        public List<Case> CaseHistory { get; }

        public string CaseName { get;}

        public string Description { get; }

        public Trial Trial { get;}

        public DivorceForm  DivorceForm { get; }

        public DivorceMechanism DivorceMechanism { get; }

        public Guid FileId { get; }

        public File File { get; }

        public DateTime StartDate { get;}
    }
}
