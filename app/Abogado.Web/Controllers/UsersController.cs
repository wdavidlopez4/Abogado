using Abogado.Application.UsersServices.GetAllUsersByName;
using Abogado.Application.UsersServices.GetUserId;
using Abogado.Application.UsersServices.Login;
using Abogado.Application.UsersServices.ModifyUser;
using Abogado.Application.UsersServices.Register;
using Abogado.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Abogado.Web.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IMediator mediator;

        public UsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetUsersByName(string filterName)
        {
            List<GetAllUsersByNameDTO> dto;
            GetAllUsersByNameQuery query = new()
            {
                FilterName = filterName,
            };

            dto = mediator.Send(query).Result;
            return View("Index", dto);
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            ViewData["Excepcion"] = TempData["Excepcion"];
            return View();
        }

        [Authorize(Roles = "abogado")]
        public IActionResult Register()
        {
            return View();
        }

        [Authorize(Roles = "abogado")]
        public async Task<IActionResult> RegisterUser(RegisterUserVM user)
        {

            RegisterCommand command = new()
            {
                Name = user.Name,
                LastName = user.LastName,
                Mail = user.Mail,
                EncriptPassword = user.Password,
                Role = user.Role,
            };

            await mediator.Send(command);

            return RedirectToAction("Index", "Users");
        }

        [Authorize(Roles = "abogado")]
        public async Task<IActionResult> Edit(string Id)
        {
            GetUserIdDTO dto;
            GetUserIdQuery query = new()
            {
                Id = Id,
            };

            dto = await mediator.Send(query);

            return View("Edit", dto);
        }

        [Authorize(Roles = "abogado")]
        public async Task<IActionResult> EditUser(EditUserVM user)
        {
            ModifyUserCommand command = new()
            {
                UserId = user.UserId,
                Name = user.Name,
                LastName = user.Lastname,
                Mail = user.Email,
            };

            await mediator.Send(command);

            return RedirectToAction("Index", "Users");
        }

        [HttpPost]
        [AllowAnonymous]
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
