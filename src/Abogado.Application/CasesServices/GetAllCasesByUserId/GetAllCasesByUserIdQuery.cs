using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.CasesServices.GetAllCasesByUserId
{
    public class GetAllCasesByUserIdQuery : IRequest<List<GetAllCasesByUserIdDTO>>
    {
        public string UserId { get; set; }
    }
}
