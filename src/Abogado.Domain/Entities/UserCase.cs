using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Domain.Entities
{
    public class UserCase : Entity
    {
        public Guid UserId { get; }

        public User User { get; }

        public Guid CaseId { get; }

        public Case Case { get; }

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
