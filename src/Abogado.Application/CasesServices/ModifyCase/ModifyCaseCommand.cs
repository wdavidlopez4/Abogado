using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.CasesServices.ModifyCase
{
    public class ModifyCaseCommand : IRequest<int>
    {
        public string Id { get; set; }

        public string CaseName { get; set; }

        public string Description { get; set; }
    }
}
