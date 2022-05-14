using Abogado.Domain.Enums;
using Ardalis.GuardClauses;
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

        public string CaseName { get; }

        public string Description { get; }

        public Trial Trial { get; }

        public DivorceForm DivorceForm { get; }

        public DivorceMechanism DivorceMechanism { get; }

        public Guid FileId { get; }

        public File File { get; }

        public DateTime StartDate { get; }

        private Case(Guid userId, string caseName, string description, Trial trial, DivorceForm divorceForm,
            DivorceMechanism divorceMechanism, Guid fileId, DateTime startDate)
        {
            UserId = userId;
            CaseName = Guard.Against.NullOrEmpty(caseName, nameof(caseName));
            Description = Guard.Against.NullOrEmpty(description);
            Trial = trial;
            DivorceForm = divorceForm;
            DivorceMechanism = divorceMechanism;
            FileId = fileId;
            StartDate = startDate;
        }

        public static Case Build(Guid userId, string caseName, string description, Trial trial, DivorceForm divorceForm,
            DivorceMechanism divorceMechanism, Guid fileId, DateTime startDate)
        {
            return new Case(userId, caseName, description, trial, divorceForm, divorceMechanism, fileId, startDate);
        }

        public void AddCase(Case caseHistory)
        {
            CaseHistory.Add(caseHistory);
        }
    }

}
