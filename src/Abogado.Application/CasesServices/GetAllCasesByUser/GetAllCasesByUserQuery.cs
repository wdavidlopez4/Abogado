using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.CasesServices.GetAllCasesByUser
{
    public class GetAllCasesByUserQuery : IRequest<List<GetAllCasesByUserDTO>>
    {
        public string Id { get; set; }

        public string NameUser { get; set; }    
    }
}
