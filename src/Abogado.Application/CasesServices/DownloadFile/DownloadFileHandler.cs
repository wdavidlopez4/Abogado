using Abogado.Domain.Entities;
using Abogado.Domain.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.CasesServices.DownloadFile
{
    public class DownloadFileHandler : IRequestHandler<DownloadFileQuery, DownloadFileDTO>
    {
        private readonly IRepository repository;

        public DownloadFileHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<DownloadFileDTO> Handle(DownloadFileQuery request, CancellationToken cancellationToken)
        {
            //consulto el caso 
            var caso = await this.repository.GetNested<Case>(x => x.Id.ToString() == request.CasoId, nameof(File));

            //leo el archivo  y lo comvierto a strinam
            return new DownloadFileDTO
            {
                File = new FileStream(caso.File.FilePath, FileMode.Open)
            }; 
        }
    }
}
