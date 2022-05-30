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
        public string Id { get; set; }

        public List<UserDTO> Users { get; private set; }

        public string CaseName { get; private set; }

        public string Description { get; private set; }

        public Trial Trial { get; private set; }

        public DivorceForm DivorceForm { get; private set; }

        public DivorceMechanism DivorceMechanism { get; private set; }

        public string FileId { get; private set; }

        public DateTime StartDate { get; private set; }

        public class UserDTO
        {

            public string Id { get; set; }

            public Role Role { get; }

            public string Name { get; set; }

            public string Lastname { get; set; }

            public string Email { get; set; }

        }
    }
}
