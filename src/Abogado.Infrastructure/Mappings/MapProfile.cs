using Abogado.Application.CasesServices.GetAllCases;
using Abogado.Application.CasesServices.GetAllCasesByUser;
using Abogado.Application.CasesServices.GetAllCasesByUserId;
using Abogado.Application.CasesServices.GetByCaseId;
using Abogado.Application.CasesServices.GetCaseByUserId;
using Abogado.Application.CasesServices.GetCasesOfCase;
using Abogado.Application.MeetingServices.GetAllMeetingsByUserId;
using Abogado.Application.MeetingServices.GetAllMeetingsByUserName;
using Abogado.Application.MeetingServices.GetMeetingById;
using Abogado.Application.UsersServices.GetAllUsers;
using Abogado.Application.UsersServices.GetAllUsersByName;
using Abogado.Application.UsersServices.GetUserId;
using Abogado.Application.UsersServices.Login;
using Abogado.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Infrastructure.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            this.CreateMap<User, GetUserIdDTO>();
            this.CreateMap<Case, GetUserIdDTO.CaseDTO>();
            this.CreateMap<Meeting, GetUserIdDTO.MeetingDTO>();
            this.CreateMap<User, GetAllUsersByNameDTO>();
            this.CreateMap<Meeting, GetAllUsersByNameDTO.MeetingDTO>();
            this.CreateMap<Case, GetAllUsersByNameDTO.CaseDTO>();
            this.CreateMap<Meeting, GetMeetingByIdDTO>();
            this.CreateMap<User, GetAllMeetingsByUserIdDTO>();
            this.CreateMap<User, GetAllMeetingsByUserIdDTO.UserDTO>();
            this.CreateMap<Meeting, GetAllMeetingsByUserIdDTO>();
            this.CreateMap<Case, GetByCaseIdDTO>();
            this.CreateMap<User, GetByCaseIdDTO.UserDTO>();
            this.CreateMap<Case, GetAllCasesByUserDTO>();
            this.CreateMap<User, GetAllCasesByUserDTO.UserDTO>();
            this.CreateMap<User, LoginDTO>();
            this.CreateMap<User, GetCaseByUserDTO.UserDTO>();
            this.CreateMap<Meeting, GetCaseByUserDTO>();
            this.CreateMap<Case, GetCaseByUserDTO>();
            this.CreateMap<User, GetCaseByUserDTO.UserDTO>();
            this.CreateMap<User, GetCaseByUserIdDTO.UserDTO>();
            this.CreateMap<Case, GetCaseByUserIdDTO>();
            this.CreateMap<Case, GetByCaseIdDTO.CaseDTO>();
            this.CreateMap<Case, GetAllCasesByUserIdDTO>();
            this.CreateMap<User, GetAllCasesByUserIdDTO.UserDTO>();
            this.CreateMap<Case, GetAllCasesDTO>();
            this.CreateMap<User, GetAllCasesDTO.UserDTO>();
            this.CreateMap<Case, GetAllCasesDTO.CaseDTO>();
            this.CreateMap<User, GetAllUsersDTO>();
            this.CreateMap<Meeting, GetAllUsersDTO.MeetingDTO>();
            this.CreateMap<Case, GetCasesOfCaseDTO>();
            this.CreateMap<User, GetCasesOfCaseDTO.UserDTO>();
        }
    }
}
