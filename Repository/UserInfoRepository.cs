using Entity.model;
using Repository.EFCore;
using Repository.IRepository;

namespace Repository
{
    public class UserInfoRepository :BaseRepository<UserInfo>, IUserInfoRepository
    {
        public UserInfoRepository(MyDbContext myDbContext) : base(myDbContext) { }
      
        // 实现自己独有的方法。
    }
}
