
using Abogado.Domain.Entities;
using Abogado.Domain.Ports;
using Ardalis.GuardClauses;
using MediatR;
using System;

namespace Abogado.Application.MeetingServices.ModifyMeeting
{
    public class ModifyMeetingHandler : IRequestHandler<ModifyMeetingCommand, int>
    {
        private readonly IRepository repository;

        public ModifyMeetingHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> Handle(ModifyMeetingCommand request, CancellationToken cancellationToken)
        {
            Meeting meeting;

            //Verificar que la peticion no se encuentre nula
            Guard.Against.Null(request, nameof(request));

            if (repository.Exists<Meeting>(x => x.Id.ToString() == request.Id) is false)
                throw new Exception("La cita no se encuentra");

            //Obtener la cita si existe y cambiar atributos
            meeting =  await repository.Get<Meeting>(x => x.Id.ToString() == request.Id);
            meeting.ChangeAttributes(request.Date);

            //Actualizar entidad
            await repository.Update<Meeting>(meeting);
            await repository.Commit();

            return 0;
        }
    }
}
