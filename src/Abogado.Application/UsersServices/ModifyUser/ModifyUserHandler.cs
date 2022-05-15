using Abogado.Domain.Entities;
using Abogado.Domain.Ports;
using Ardalis.GuardClauses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.UsersServices.ModifyUser
{

    public class ModifyUserHandler : IRequestHandler<ModifyUserCommand, int>
    {
        private readonly IRepository repository;

        public ModifyUserHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> Handle(ModifyUserCommand request, CancellationToken cancellationToken)
        {
            User user;

            //Verificar que la peticion no este nula
            Guard.Against.Null(request, nameof(request));

            if (repository.Exists<User>(x => x.Email == request.Mail) is false)
                throw new Exception("El Usuario no se encuentra registrado");

            user = await repository.Get<User>(x => x.Email == request.Mail);

            //Cambiar atributos del usuario
            user.ChangeAtributtes(request.Name, request.LastName, request.Mail);

            await repository.Update<User>(user);
            await repository.Commit();

            return 0;
        }
    }
}
