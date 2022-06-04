using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.CasesServices.GetAllCases
{
    public class GetAllCasesQuery: IRequest<List<GetAllCasesDTO>>
    {
   
    }
}
