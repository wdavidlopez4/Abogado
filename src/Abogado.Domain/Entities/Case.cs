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
        public List<User> Users { get; private set; }

        public List<Case> CaseHistory { get; private set; }

        public string CaseName { get; private set; }

        public string Description { get; private set; }

        public Trial Trial { get; private set; }

        public DivorceForm DivorceForm { get; private set; }

        public DivorceMechanism DivorceMechanism { get; private set; }

        public Guid FileId { get; private set; }

        public FileDocument File { get; private set; }

        public DateTime StartDate { get; private set; }

        public bool IsPrincipalCase { get; private set; }

        private Case()
        {

        }

        private Case(string caseName, string description, Trial trial, DivorceForm divorceForm,
            DivorceMechanism divorceMechanism, Guid fileId, DateTime startDate)
        {
            CaseName = Guard.Against.NullOrEmpty(caseName, nameof(caseName));
            Description = Guard.Against.NullOrEmpty(description);
            Trial = trial;
            DivorceForm = divorceForm;
            DivorceMechanism = divorceMechanism;
            FileId = fileId;
            StartDate = startDate;

            this.Users = new();
            this.CaseHistory = new();
        }

        public static Case Build(string caseName, string description, Trial trial, DivorceForm divorceForm,
            DivorceMechanism divorceMechanism, Guid fileId, DateTime startDate)
        {
            return new Case(caseName, description, trial, divorceForm, divorceMechanism, fileId, startDate);
        }

        public void AddCaseHistory(Case caseHistory)
        {
            if (CaseHistory is null)
                this.CaseHistory = new();

            CaseHistory.Add(caseHistory);
        }

        public void AddUser(User user)
        {
            if (Users is null)
                this.Users = new List<User>();

            if (Users.Count >= 2)
                throw new Exception("solamente puede tener dos objetos.");
            else if (Users.Any(x => x.Role == user.Role))
                throw new Exception("La reunion solo puede tener asociado un abogado y un cliente");

            Users.Add(user);
        }

        public void SetIsPrincipalCase(bool isPrincipal)
        {
            IsPrincipalCase = isPrincipal;
        }

        public void ChangeAtributtes(string caseName, string description, Guid? fileId = null)
        {
            CaseName = Guard.Against.NullOrEmpty(caseName, nameof(caseName));
            Description = Guard.Against.NullOrEmpty(description);
            FileId = fileId != null ? fileId.Value : this.FileId;
        }
    }

}
