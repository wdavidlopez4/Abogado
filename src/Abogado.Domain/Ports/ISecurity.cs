using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Domain.Ports
{
    public interface ISecurity
    {
        public string EncryptPassword(string password);
    }
}
