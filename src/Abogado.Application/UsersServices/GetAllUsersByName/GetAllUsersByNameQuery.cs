using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.UsersServices.GetAllUsersByName
{
    public class GetAllUsersByNameQuery : IRequest<List<GetAllUsersByNameDTO>>
    {
        public string FilterName { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}
