using Abogado.Application.CasesServices.GetAllCasesByUser;
using Abogado.Application.CasesServices.GetByCaseId;
using Abogado.Application.MeetingServices.GetAllMeetingsByUser;
using Abogado.Application.MeetingServices.GetMeetingById;
using Abogado.Application.UsersServices.GetAllUsersByName;
using Abogado.Application.UsersServices.GetUserId;
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
            this.CreateMap <Meeting, GetUserIdDTO.MeetingDTO> ();
            this.CreateMap <User, GetAllUsersByNameDTO> ();
            this.CreateMap <Meeting, GetMeetingByIdDTO> ();
            this.CreateMap <User, GetAllMeetingsByUserDTO> ();
            this.CreateMap <Meeting, GetAllMeetingsByUserDTO.MeetingDTO> ();
            this.CreateMap <Case, GetByCaseIdDTO> ();
            this.CreateMap <User, GetByCaseIdDTO.UserCaseDTO> ();
            this.CreateMap <User, GetAllCasesByUserDTO> ();
            this.CreateMap <Case, GetAllCasesByUserDTO.CaseDTO> ();
        }
    }
}
