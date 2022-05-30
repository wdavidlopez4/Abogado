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

        public List<CaseDTO> Cases { get; set; }

        public List<MeetingDTO> Meetings { get; set; }


        public class MeetingDTO
        {
            public string Id { get; set; }

            public DateTime Date { get; set; }
        }

        public class CaseDTO
        {
            public string CaseName { get; set; }

            public string Description { get; set; }

            public Trial Trial { get; set; }

            public DivorceForm DivorceForm { get; set; }

            public DivorceMechanism DivorceMechanism { get; set; }

            public Guid FileId { get; set; }

            public FileDocument File { get; set; }

            public DateTime StartDate { get; set; }
        }
    }


   
}
