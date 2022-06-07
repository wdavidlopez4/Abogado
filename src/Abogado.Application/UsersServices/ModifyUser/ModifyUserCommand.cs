using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.UsersServices.ModifyUser
{
    public class ModifyUserCommand : IRequest<int>
    {
        public string UserId { get; set; }

        public string Name { get; set; }

        public string LastName  { get; set; }

        public string Mail { get; set; }

        public string Password { get; set; }
    }
}
