using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.CasesServices.GetCaseByUserId
{
    public class GetCaseByUserIdQuery : IRequest<GetCaseByUserIdDTO>
    {
        public string UserId { get; set; }
    }
}
