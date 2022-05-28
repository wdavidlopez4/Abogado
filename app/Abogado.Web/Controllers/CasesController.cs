using Abogado.Application.CasesServices.CreateCase;
using Abogado.Application.CasesServices.ModifyCase;
using Abogado.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Abogado.Web.Controllers
{
    [Authorize]
    public class CasesController : Controller
    {
        private readonly IMediator mediator;

        public CasesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "abogado")]
        public IActionResult Register()
        {
            return View();
        }

        [Authorize(Roles = "abogado")]
        public IActionResult RegisterCase(RegisterCaseVM registerCase)
        {
            CreateCaseCommand command = new()
            {
                CaseName = registerCase.CaseName,
                Description = registerCase.Description,
                Trial = registerCase.Trial,
                DivorceForm = registerCase.DivorceForm,
                DivorceMechanism = registerCase.DivorceMechanism,
                Archivo = registerCase.Archivo,
                StartDate = registerCase.StartDate,
            };

            mediator.Send(command);

            return View("Index");
        }

        [Authorize(Roles = "abogado")]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "abogado")]
        public IActionResult Edit(EditCaseVM editCase)
        {
            ModifyCaseCommand command = new()
            {
                CaseName = editCase.CaseName,
                Description = editCase.Description,
                Archivo = editCase.Archivo,
            };

            mediator.Send(command);
            return View("Index");
        }

    }
}
