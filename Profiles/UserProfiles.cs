using AutoMapper;
using ms_partnership.Models.Entities;
using ms_partnership.Models.Entities.Dtos.User;

namespace ms_partnership.Profiles
{
    public class UserProfiles : Profile
    {  
        public UserProfiles()
        {
            CreateMap<AddUserDto, User>();
            CreateMap<User, ReadUserDto>();
            CreateMap<UpdateUserDto, User>();
        }
    }
}