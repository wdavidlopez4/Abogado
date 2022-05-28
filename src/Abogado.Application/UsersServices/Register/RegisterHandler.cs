using Abogado.Domain.Entities;
using Abogado.Domain.Ports;
using Ardalis.GuardClauses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.UsersServices.Register
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, int>
    {
        private readonly IRepository repository;
        private readonly ISecurity security;

        public RegisterHandler(IRepository repository, ISecurity security)
        {
            this.repository = repository;
            this.security = security;
        }

        public async Task<int> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            User user;

            //Comprobar que el request no este nulo
            Guard.Against.Null(request, nameof(request));

            //Verificar que el usuario no este registrado
            if (repository.Exists<User>(x => x.Email == request.Mail))
                throw new Exception("El correo ya existe");

            //Crear usuario
            user = User.Build(
                role: request.Role,
                name: request.Name,
                lastname: request.LastName,
                email: request.Mail,
                encriptPassword: security.EncryptPassword(request.EncriptPassword));

            //Guardar Usuario
            await repository.Save(user);
            await repository.Commit();

            return 0;
        }
    }
}
