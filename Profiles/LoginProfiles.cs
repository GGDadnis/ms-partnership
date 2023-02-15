using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ms_partnership.Models.Entities;
using ms_partnership.Models.Entities.Dtos.Login;

namespace ms_partnership.Profiles
{
    public class LoginProfiles : Profile
    {
        public LoginProfiles()
        {
        CreateMap<AddLoginDto, Login>();
        CreateMap<Login, ReadLoginDto>();
        CreateMap<UpdateLoginDto, Login>();
        }
    }
}