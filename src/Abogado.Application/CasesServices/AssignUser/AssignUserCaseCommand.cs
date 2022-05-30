using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.CasesServices.AssignUser
{
    public class AssignUserCaseCommand:IRequest<int>
    {
        public string UserId { get; set; } 

        public string CaseId { get; set; }
    }
}
