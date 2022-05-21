using Abogado.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.UsersServices.Login
{
    public class LoginDTO
    {
        public string Id { get; set; } 

        public Role Role { get; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

    }
}
