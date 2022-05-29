using Abogado.Domain.Entities;
using Abogado.Domain.Ports;
using Ardalis.GuardClauses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.MeetingServices.GetMeetingById
{
    public class GetMeetingByIdHandler : IRequestHandler<GetMeetingByIdQuery, GetMeetingByIdDTO>
    {
        private readonly IRepository repository;

        private readonly IMapObject mapObject;

        public GetMeetingByIdHandler(IRepository repository, IMapObject mapObject)
        {
            this.repository = repository;
            this.mapObject = mapObject;
        }

        public async Task<GetMeetingByIdDTO> Handle(GetMeetingByIdQuery request, CancellationToken cancellationToken)
        {
            Meeting meeting;

            //Verificar que la peticion no este nula
            Guard.Against.Null(request, nameof(request));

            //Verificar si la cita existe, si existe obtenerla
            if (repository.Exists<Meeting>(x => x.Id.ToString() == request.Id) is false)
                throw new Exception("La cita no se encuentra registrada");

            meeting = await repository.GetNested<Meeting>(x => x.Id.ToString() == request.Id, nameof(Meeting.Users));

            //Mapear objeto y retornar
            return mapObject.Map<Meeting, GetMeetingByIdDTO>(meeting);
        }
    }
}
