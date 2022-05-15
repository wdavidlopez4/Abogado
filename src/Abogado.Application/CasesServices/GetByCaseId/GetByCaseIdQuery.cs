using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.CasesServices.GetByCaseId
{
    public class GetByCaseIdQuery : IRequest<GetByCaseIdDTO>
    {
        public string Id { get; set; } 
    }
}
