using Abogado.Domain.Ports;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Infrastructure.Persistences.BlobFile
{
    public class RepositoryDocumnet : IRepositoryDocumnet
    {
        public async Task<string> SubirArchivo(IFormFile archivo)
        {
            Random rnd = new();
            int rndx = rnd.Next(0, 1000000);

            string ruta = Path.Combine(Directory.GetCurrentDirectory(), "CasosPDF", rndx + ".pdf");

            using var stream = new FileStream(ruta, FileMode.Create);
            await archivo.CopyToAsync(stream);

            return ruta;
        }

        public FileStream AbrirArchivo(string rutaArchivo)
        {
            return new FileStream(rutaArchivo, FileMode.Open);
        }

    }
}
