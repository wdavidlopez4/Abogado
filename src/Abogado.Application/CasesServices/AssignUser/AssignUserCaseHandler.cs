using Abogado.Domain.Entities;
using Abogado.Domain.Ports;
using Ardalis.GuardClauses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.CasesServices.AssignUser
{
    public class AssignUserCaseHandler:IRequestHandler<AssignUserCaseCommand, int>
    {
        private readonly IRepository repository;

        public AssignUserCaseHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> Handle(AssignUserCaseCommand request, CancellationToken cancellationToken)
        {
            User user;
            Case caseAux;

            Guard.Against.Null(request, nameof(request));

            if (repository.Exists<User>(x => x.Id.ToString() == request.UserId) is false)
                throw new Exception("El usuario no existe");

            if (repository.Exists<Case>(x => x.Id.ToString() == request.CaseId)is false)
                throw new Exception("El caso no existe");

            user = await repository.Get<User>(x => x.Id.ToString() == request.UserId);

            caseAux = await repository.Get<Case>(x =>x.Id.ToString() == request.CaseId);

            caseAux.AddUser(user);

            await repository.Update<Case>(caseAux);
            await repository.Commit();

            return 0;
        }
    }
}
