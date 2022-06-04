using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.UsersServices.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<GetAllUsersDTO>>
    {

    }
}
