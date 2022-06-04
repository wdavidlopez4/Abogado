using Abogado.Application.CasesServices.GetAllCases;
using Abogado.Application.CasesServices.GetAllCasesByUser;
using Abogado.Application.CasesServices.GetAllCasesByUserId;
using Abogado.Application.CasesServices.GetByCaseId;
using Abogado.Application.CasesServices.GetCaseByUserId;
using Abogado.Application.MeetingServices.GetAllMeetingsByUserId;
using Abogado.Application.MeetingServices.GetAllMeetingsByUserName;
using Abogado.Application.UsersServices.GetAllUsers;
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
            this.CreateMap<GetCaseByUserIdDTO, CaseVM>();
            this.CreateMap<GetCaseByUserIdDTO.UserDTO, CaseVM.UserDTO>();
            this.CreateMap<GetAllCasesByUserDTO, CaseVM>();
            this.CreateMap<GetAllCasesByUserDTO.UserDTO, CaseVM.UserDTO>();
            this.CreateMap<GetByCaseIdDTO.CaseDTO, CaseVM>();
            this.CreateMap<GetAllCasesByUserIdDTO, CaseVM>();
            this.CreateMap<GetAllCasesByUserIdDTO.UserDTO, CaseVM.UserDTO>();
            this.CreateMap<GetAllCasesDTO, CaseVM>();
            this.CreateMap<GetAllCasesDTO.CaseDTO, CaseVM.CaseDTO>();
            this.CreateMap<GetAllCasesDTO.UserDTO, CaseVM.UserDTO>();
            this.CreateMap<GetAllUsersDTO, UsersVM>();
            this.CreateMap<GetAllUsersDTO.MeetingDTO, UsersVM.MeetingDTO>();


            this.CreateMap<GetCaseByUserDTO, MeetingsUsersVM>();
            this.CreateMap<GetCaseByUserDTO.UserDTO, MeetingsUsersVM.UserDTO>();
        }
    }
}
