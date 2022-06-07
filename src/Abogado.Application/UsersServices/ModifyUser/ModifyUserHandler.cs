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

        private readonly ISecurity security;

        public ModifyUserHandler(IRepository repository, ISecurity security)
        {
            this.repository = repository;
            this.security = security;
        }

        public async Task<int> Handle(ModifyUserCommand request, CancellationToken cancellationToken)
        {
            User user;
            string encriptPassword;

            //Verificar que la peticion no este nula
            Guard.Against.Null(request, nameof(request));


            //Verificar si el usuario existe, si existe obtenerlo
            if (repository.Exists<User>(x => x.Id.ToString() == request.UserId) is false)
                throw new Exception("El Usuario no se encuentra registrado");

            user = await repository.Get<User>(x => x.Id.ToString() == request.UserId);

            //Verificar que el correo no este ya registrado
            if (repository.Exists<User>(x => x.Email == request.Mail) && user.Email != request.Mail)
                throw new Exception("El correo ya se encuentra registrado");

            encriptPassword = security.EncryptPassword(request.Password);

            //Cambiar atributos del usuario
            user.ChangeAtributtes(request.Name, request.LastName, request.Mail, encriptPassword);

            await repository.Update<User>(user);
            await repository.Commit();

            return 0;
        }
    }
}
