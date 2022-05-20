using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Domain.Ports
{
    public interface IRepositoryDocumnet
    {
        public Task<string> SubirArchivo(IFormFile archivo);

        public FileStream AbrirArchivo(string rutaArchivo);
    }
}
