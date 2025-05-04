using AutoMapper;
using Entity.model;
using Entity.Request.User;
using Entity.vo;

namespace WebAPI.Profiles
{
    public class UserInfoProfile : Profile
    {
        public UserInfoProfile()
        {
            CreateMap<UserInfo, UserInfoVo>();
            CreateMap<RegistrationForm, UserInfo>();
        }
    }
}
