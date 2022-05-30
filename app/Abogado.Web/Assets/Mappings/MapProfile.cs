using Abogado.Application.MeetingServices.GetAllMeetingsByUserId;
using Abogado.Application.MeetingServices.GetAllMeetingsByUserName;
using Abogado.Application.UsersServices.GetAllUsersByName;
using Abogado.Application.UsersServices.GetUserId;
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
            this.CreateMap<GetUserIdDTO, UsersVM>();
            this.CreateMap<GetUserIdDTO.MeetingDTO, UsersVM.MeetingDTO>();
            this.CreateMap<GetUserIdDTO.CaseDTO, UsersVM.CaseDTO>();
            this.CreateMap<GetAllUsersByNameDTO, UsersVM>();
            this.CreateMap<GetAllUsersByNameDTO.CaseDTO, UsersVM.CaseDTO>();
            this.CreateMap<GetAllUsersByNameDTO.MeetingDTO, UsersVM.MeetingDTO>();


           // this.CreateMap<GetAllMeetingsByUserIdDTO.MeetingDTO, MeetingsUsersVM.MeetingDTO>();
            this.CreateMap<GetAllMeetingsByUserNameDTO, MeetingsUsersVM>();
            this.CreateMap<GetAllMeetingsByUserNameDTO.UserDTO, MeetingsUsersVM.UserDTO>();
            //this.CreateMap<GetAllMeetingsByUserNameDTO.MeetingDTO, MeetingsUsersVM.MeetingDTO>();
        }
    }
}
