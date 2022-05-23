using Abogado.Domain.Entities;
using Abogado.Domain.Ports;
using Ardalis.GuardClauses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application.UsersServices.Login
{
    public class LoginHandler : IRequestHandler<LoginCommand, LoginDTO>
    {

        private readonly IRepository repository;

        private readonly ISecurity security;

        private readonly IMapObject mapObject;

        public LoginHandler(IRepository repository, ISecurity security, IMapObject mapObject)
        {
            this.repository = repository;
            this.security = security;
            this.mapObject = mapObject;
        }

        public async Task<LoginDTO> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            User user;

            //Verificar que la peticion no se encuentre nula
            Guard.Against.Null(request, nameof(request));

            //Comprobar si el usuario existe
            if (repository.Exists<User>(x => x.Email == request.Mail) == false)
                throw new Exception("El Usuario no se encuentra registrado, compruebe el correo");

            //Obtener el usuario
            user = await repository.Get<User>(x => x.Email == request.Mail);

            //Verificar la contraseña
            if (user.EncriptPassword != this.security.EncryptPassword(request.Password))
                throw new Exception("La contraseña es incorrecta");

            //Mapear y retornar
            return mapObject.Map<User, LoginDTO>(user);
        }
    }
}
