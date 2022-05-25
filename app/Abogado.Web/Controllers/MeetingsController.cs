using Abogado.Application.MeetingServices.CreateMeeting;
using Abogado.Application.MeetingServices.GetAllMeetingsByUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Abogado.Web.Controllers
{
    public class MeetingsController : Controller
    {

        private IMediator mediator;

        public MeetingsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(DateTime date)
        {
            CreateMeetingCommand command = new()
            {
                Date = date
            };

            mediator.Send(command);

            return RedirectToAction("Index", "Meetings");
        }

        public IActionResult Get(string userId, string name)
        {
            List<GetAllMeetingsByUserDTO> dto;
            GetAllMeetingsByUserQuery query = new()
            {
                UserId = userId,
                UserName = name,
            };

            dto = mediator.Send(query).Result;

            return Index();
        }


    }
}











