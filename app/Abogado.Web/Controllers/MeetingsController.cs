using Abogado.Application.MeetingServices.AssignUser;
using Abogado.Application.MeetingServices.CreateMeeting;
using Abogado.Application.MeetingServices.GetAllMeetingsByUserId;
using Abogado.Application.MeetingServices.GetAllMeetingsByUserName;
using Abogado.Application.MeetingServices.GetMeetingById;
using Abogado.Application.MeetingServices.ModifyMeeting;
using Abogado.Application.UsersServices.GetAllUsersByName;
using Abogado.Domain.Ports;
using Abogado.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Abogado.Web.Controllers
{
    [Authorize]
    public class MeetingsController : Controller
    {

        private readonly IMediator mediator;

        private readonly IMapObject mapObject;

        public MeetingsController(IMediator mediator, IMapObject mapObject)
        {
            this.mediator = mediator;
            this.mapObject = mapObject;
        }

        public IActionResult Index()
        {
            ViewData["Excepcion"] = TempData["Excepcion"];
            var userIdAux = GetClaim("Id");

            List<GetAllMeetingsByUserIdDTO> dto;
            List<MeetingsUsersVM> listMeetingUserVM;
            GetAllMeetingsByUserName query = new()
            {
                UserId = userIdAux,
            };

            dto = mediator.Send(query).Result;
            listMeetingUserVM = mapObject.Map<List<GetAllMeetingsByUserIdDTO>, List<MeetingsUsersVM>>(dto);

            return View("Index", listMeetingUserVM);
        }


        public IActionResult Crear()
        {
            return View();
        }

        public IActionResult Editar()
        {
            return View();
        }

        public IActionResult RegisterMeetingByAux()
        {
            return View();
        }

        public IActionResult AssignUserView(string Id)
        {
            HttpContext.Session.SetString("MeetigId", Id);
            TempData["Id"] = Id;
            return View();
        }

        public async Task<IActionResult> AssignUser(string userId)
        {
            TempData["Id"] = TempData["Id"];
            AssignUserCommand command = new()
            {
                //MeetingId = TempData["Id"].ToString(),
                MeetingId = HttpContext.Session.GetString("MeetigId"),
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
            return View("AssignUserView", dto);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(DateTime date)
        {
            string userId;
            userId = GetClaim("Id");

            CreateMeetingCommand command = new()
            {
                Date = date,
                UserId = userId,
            };

            await mediator.Send(command);

            return RedirectToAction("Index", "Meetings");
        }

        private string GetClaim(string type)
        {
            return HttpContext.User.Claims.FirstOrDefault(x => x.Type == type)?.Value;
        }

        public IActionResult Edit(string id)
        {
            GetMeetingByIdDTO dto;
            GetMeetingByIdQuery query = new()
            {
                Id = id,
            };

            dto = mediator.Send(query).Result;

            return View("Editar", dto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string Id, DateTime date)
        {
            ModifyMeetingCommand command = new()
            {
                Id = Id,
                Date = date,
            };

            await mediator.Send(command);

            return RedirectToAction("Index", "Meetings");
        }

        public async Task<IActionResult> GetMeetingsByUserName(string name)
        {
            List<GetAllMeetingsByUserNameDTO> dto;
            List<MeetingsUsersVM> listMeetingUserVM;
            GetAllMeetingsByUserNameQuery query = new()
            {
                Name = name,
            };

            dto = await mediator.Send(query);

            listMeetingUserVM = mapObject.Map<List<GetAllMeetingsByUserNameDTO>, List<MeetingsUsersVM>>(dto);

            return View("Index", listMeetingUserVM);
        }

    }
}











