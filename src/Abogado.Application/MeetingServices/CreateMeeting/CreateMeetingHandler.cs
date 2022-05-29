using Abogado.Domain.Entities;
using Abogado.Domain.Enums;
using Abogado.Domain.Ports;
using Ardalis.GuardClauses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.MeetingServices.CreateMeeting
{
    public class CreateMeetingHandler : IRequestHandler<CreateMeetingCommand, int>
    {

        private readonly IRepository repository;

        public CreateMeetingHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> Handle(CreateMeetingCommand request, CancellationToken cancellationToken)
        {
            User user;
            Meeting meeting;

            //Verificar que la peticion no se encuentre nula
            Guard.Against.Null(request, nameof(request));

            //Crear la cita
            meeting = Meeting.Build(request.Date);

            user = await repository.Get<User>(x => x.Id.ToString() == request.UserId);

            meeting.AddUser(user);

            //Guardar la cita
            await this.repository.Save<Meeting>(meeting);
            await repository.Commit();

            return 0;

        }
    }
}
