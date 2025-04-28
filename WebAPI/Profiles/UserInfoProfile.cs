using AutoMapper;
using Entity.model;
using Entity.vo;

namespace WebAPI.Profiles
{
    public class UserInfoProfile : Profile
    {
        public UserInfoProfile()
        {
            CreateMap<UserInfo, UserInfoVo>();
        }
    }
}
