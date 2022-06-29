using Abogado.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.CasesServices.CreateCase
{
    public class CreateCaseCommand : IRequest<int>
    {
        public string LawyerId { get; set; }

        public string CaseName { get; set; }

        public string Description { get; set; }

        public Proceso Trial { get; set; }

        public DivorceForm DivorceForm { get; set; }

        public DivorceMechanism DivorceMechanism { get; set; }

        public IFormCollection Archivo { get; set; }

        public DateTime StartDate { get; set; }
    }
}
