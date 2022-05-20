using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Domain.Entities
{
    public class UserCase : Entity
    {
        public Guid UserId { get; private set; }

        public User User { get; private set; }

        public Guid CaseId { get; private set; }

        public Case Case { get; private set; }

        private UserCase()
        {

        }

        private UserCase(User user, Case @case)
        {
            User = user;
            Case = @case;
        }

        public static UserCase Build(User user, Case @case)
        {
            return new UserCase(user, @case);
        }
    }
}
