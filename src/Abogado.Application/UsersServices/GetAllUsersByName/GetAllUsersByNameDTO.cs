using Abogado.Domain.Entities;
using Abogado.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.UsersServices.GetAllUsersByName
{
    public class GetAllUsersByNameDTO
    {
        public string Id { get; set; }

        public Role Role { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public List<CaseDTO> Cases { get; private set; }

        public List<MeetingDTO> Meetings { get; private set; }


        public class MeetingDTO
        {
            public string Id { get; set; }

            public DateTime Date { get; set; }
        }

        public class CaseDTO
        {
            public string CaseName { get; private set; }

            public string Description { get; private set; }

            public Trial Trial { get; private set; }

            public DivorceForm DivorceForm { get; private set; }

            public DivorceMechanism DivorceMechanism { get; private set; }

            public Guid FileId { get; private set; }

            public FileDocument File { get; private set; }

            public DateTime StartDate { get; private set; }
        }
    }


   
}
