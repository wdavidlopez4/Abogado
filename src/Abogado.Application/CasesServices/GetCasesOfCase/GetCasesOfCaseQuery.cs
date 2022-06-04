using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.CasesServices.GetCasesOfCase
{
    public class GetCasesOfCaseQuery : IRequest<List<GetCasesOfCaseDTO>>
    {
        public string FatherCaseId { get; set; }
    }
}
