using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }

        protected Entity()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
