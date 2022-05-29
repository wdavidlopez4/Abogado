using Abogado.Application.MeetingServices.GetAllMeetingsByUserId;
using Abogado.Application.MeetingServices.GetAllMeetingsByUserName;
using Abogado.Domain.Entities;
using Abogado.Web.Models;
using AutoMapper;

namespace Abogado.Web.Assets.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            this.CreateMap<GetAllMeetingsByUserIdDTO, MeetingsUsersVM>();
            this.CreateMap<GetAllMeetingsByUserIdDTO.UserDTO, MeetingsUsersVM.UserDTO>();
           // this.CreateMap<GetAllMeetingsByUserIdDTO.MeetingDTO, MeetingsUsersVM.MeetingDTO>();
            this.CreateMap<GetAllMeetingsByUserNameDTO, MeetingsUsersVM>();
            this.CreateMap<GetAllMeetingsByUserNameDTO.UserDTO, MeetingsUsersVM.UserDTO>();
            //this.CreateMap<GetAllMeetingsByUserNameDTO.MeetingDTO, MeetingsUsersVM.MeetingDTO>();
        }
    }
}
