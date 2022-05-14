using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Domain.Entities
{
    public class Meeting : Entity
    {
        public Guid UserId { get;}

        public User User { get; }

        public User Lawyer { get; }

        public DateTime Date { get;}
    }
}
