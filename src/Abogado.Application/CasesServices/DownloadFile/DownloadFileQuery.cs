using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.CasesServices.DownloadFile
{
    public class DownloadFileQuery : IRequest<DownloadFileDTO>
    {
        public string CasoId { get; set; }
    }
}
