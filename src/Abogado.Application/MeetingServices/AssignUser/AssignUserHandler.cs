using Abogado.Domain.Entities;
using Abogado.Domain.Ports;
using Ardalis.GuardClauses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.MeetingServices.AssignUser
{
    public class AssignUserHandler : IRequestHandler<AssignUserCommand, int>
    {
        private readonly IRepository repository;

        public AssignUserHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> Handle(AssignUserCommand request, CancellationToken cancellationToken)
        {

            User user;
            Meeting meeting;

            //Verificar que la peticion no se encuentre nula
            Guard.Against.Null(request, nameof(request));

            if (repository.Exists<User>(x => x.Id.ToString() == request.UserId) is false)
                throw new Exception("El usuario no existe");

            user = await repository.Get<User>(x => x.Id.ToString() == request.UserId);

            if (repository.Exists<Meeting>(x => x.Id.ToString() == request.MeetingId) is false)
                throw new Exception("La reunion no existe");

            meeting = await repository.GetNested<Meeting>(x => x.Id.ToString() == request.MeetingId, nameof(Meeting.Users));

            meeting.AddUser(user);

            await repository.Update<Meeting>(meeting);
            await repository.Commit();

            return 0;
        }
    }
}
