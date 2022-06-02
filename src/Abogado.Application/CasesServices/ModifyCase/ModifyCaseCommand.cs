using MediatR;
using Microsoft.AspNetCore.Http;
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

        public IFormFile Archivo { get; set; }

        public bool IsSave { get; set; }
    }
}
