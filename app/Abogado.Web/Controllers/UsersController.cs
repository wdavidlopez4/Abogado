using Abogado.Application.UsersServices.Login;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Abogado.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IMediator mediator;

        public UsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            ViewData["Excepcion"] = TempData["Excepcion"];
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(string email, string password)
        {
            LoginDTO dto = new();

            List<Claim> claims;

            var command = new LoginCommand
            {
                Mail = email,
                Password = password,
            };

            try
            {
                dto = mediator.Send(command).Result;
                claims = CreateClaims(dto);
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            }
            catch (Exception e)
            {
                TempData["Excepcion"] = e.Message;
            }
            return RedirectToAction("Index", "Home");

        }

        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }

        /// <summary>
        /// Metodo para crear claims
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        private static List<Claim> CreateClaims(LoginDTO dto)
        {
            return new List<Claim>
            {
               new Claim("Id", dto.Id),
               new Claim(ClaimTypes.Email, dto.Email),
               new Claim("Name", dto.Name),
               new Claim(ClaimTypes.Role, dto.Role.ToString())
            };
        }
    }
}
