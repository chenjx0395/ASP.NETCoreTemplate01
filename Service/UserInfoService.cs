using Entity.model;
using Repository.IRepository;
using Service.IService;

namespace Service
{
    public class UserInfoService : BaseService<UserInfo>, IUserInfoService
    {
        private readonly IUserInfoRepository userInfoRepository;
        public UserInfoService(IUserInfoRepository userInfoRepository)
        {

            repository = userInfoRepository;
            this.userInfoRepository = userInfoRepository;
        }


    }

}
