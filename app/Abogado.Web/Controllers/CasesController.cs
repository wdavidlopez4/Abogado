using Abogado.Application.CasesServices.AssignUser;
using Abogado.Application.CasesServices.CreateCase;
using Abogado.Application.CasesServices.GetAllCasesByUser;
using Abogado.Application.CasesServices.GetByCaseId;
using Abogado.Application.CasesServices.GetCaseByUserId;
using Abogado.Application.CasesServices.ModifyCase;
using Abogado.Application.UsersServices.GetAllUsersByName;
using Abogado.Domain.Enums;
using Abogado.Domain.Ports;
using Abogado.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace Abogado.Web.Controllers
{
    [Authorize]
    public class CasesController : Controller
    {
        private readonly IMediator mediator;

        private readonly IMapObject mapObject;

        public CasesController(IMediator mediator, IMapObject mapObject)
        {
            this.mediator = mediator;
            this.mapObject = mapObject;
        }

        public async Task<IActionResult> Index()
        {
            if (HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value == Role.cliente.ToString())
            {
                await GetCasesByUserId();
            }
            else
            {
                return View();
            }
            return View();
        }

        [Authorize(Roles = "abogado")]
        public IActionResult Register()
        {
            return View();
        }

        [Authorize(Roles = "abogado")]
        [HttpPost]
        public async Task<IActionResult> RegisterCase(RegisterCaseVM registerCase)
        {
            string lawyerId;
            lawyerId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value;

            CreateCaseCommand command = new()
            {
                CaseName = registerCase.CaseName,
                Description = registerCase.Description,
                Trial = registerCase.Trial,
                DivorceForm = registerCase.DivorceForm,
                DivorceMechanism = registerCase.DivorceMechanism,
                Archivo = registerCase.Archivo,
                StartDate = registerCase.StartDate,
                LawyerId = lawyerId,
            };
            await mediator.Send(command);

            return View("Index");
        }

        public IActionResult AssingCaseView(string Id)
        {
            HttpContext.Session.SetString("CaseId", Id);
            return View();
        }

        public async Task<IActionResult> AssingCase(string userId)
        {
            AssignUserCaseCommand command = new()
            {
                CaseId = HttpContext.Session.GetString("CaseId"),
                UserId = userId,
            };

            try
            {
                await mediator.Send(command);
            }
            catch (Exception e)
            {
                TempData["Excepcion"] = e.Message;
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public IActionResult GetUsers(string filterName)
        {
            TempData["Id"] = TempData["Id"];
            List<GetAllUsersByNameDTO> dto;

            GetAllUsersByNameQuery query = new()
            {
                FilterName = filterName,
            };

            dto = mediator.Send(query).Result;

            return View("AssingCaseView", dto);
        }

        public async Task<IActionResult> GetCases(string filterName)
        {
            List<CaseVM> cases;
            List<GetAllCasesByUserDTO> dto;

            GetAllCasesByUserQuery query = new()
            {
                NameCase = filterName,
            };

            dto = await mediator.Send(query);

            cases = mapObject.Map<List<GetAllCasesByUserDTO>, List<CaseVM>>(dto);

            return View("Index", cases);
        }

        public async Task<IActionResult> GetCasesByUserId()
        {
            List<CaseVM> caseAux = new();
            GetCaseByUserIdDTO dto;

            string userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value;
            
            GetCaseByUserIdQuery query = new()
            {
                    UserId = userId,
            };

            dto = await mediator.Send(query);
            caseAux.Add(mapObject.Map<GetCaseByUserIdDTO, CaseVM>(dto));

            return View("Index", caseAux);
        }

        [Authorize(Roles = "abogado")]
        public async Task<IActionResult> Edit(string Id)
        {
            GetByCaseIdDTO dto;

            GetByCaseIdQuery query = new()
            {
                Id = Id,
            };

            dto = await mediator.Send(query);

            return View(dto);
        }

        [HttpPost]
        [Authorize(Roles = "abogado")]
        public async Task<IActionResult> EditCase(EditCaseVM editCase)
        {
            ModifyCaseCommand command = new()
            {
                CaseName = editCase.CaseName,
                Description = editCase.Description,
                Archivo = editCase.Archivo,
                Id = editCase.Id,
            };

            await mediator.Send(command);

            return View("Index");
        }
    }
}
