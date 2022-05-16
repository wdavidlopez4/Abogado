using Abogado.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Infrastructure.Securities
{
    public class Security : ISecurity
    {
        public string EncryptPassword(string password)
        {
            if(password == null)
                throw new ArgumentNullException("password");

            //instancias variables
            SHA1 sha1 = SHA1Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream;
            StringBuilder sb = new StringBuilder();

            //encriptar
            stream = sha1.ComputeHash(encoding.GetBytes(password));
            for (int i = 0; i < stream.Length; i++)
            {
                sb.AppendFormat("{0:x2}", stream[i]);
            }

            return sb.ToString();
        }
    }
}
