using Abogado.Application.UsersServices.Login;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Abogado.Web.Controllers
{
    public class LoginController : Controller
    {

        private readonly IMediator mediator;

        public LoginController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(string email, string password)
        {

            var command = new LoginCommand
            {
                Mail = email,
                Password = password,
            };

            var dto = mediator.Send(command);

            if (dto.Result == 0)
            {

                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, email),
            };

                claims.Add(new Claim(ClaimTypes.Role, "Administrador"));

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
