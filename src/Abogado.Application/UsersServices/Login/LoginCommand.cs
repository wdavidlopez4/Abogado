using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.UsersServices.Login
{
    public class LoginCommand: IRequest<LoginDTO>
    {
        public string Mail { get; set; }

        public string Password { get; set; }
    }
}
