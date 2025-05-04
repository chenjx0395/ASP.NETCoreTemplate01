using Common.enums;

namespace Entity.model
{
    public class UserInfo : BaseEntity<Guid>
    {

        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// 密码
        /// </summary>
        public string PasswordHash { get; set; } = string.Empty;

        /// <summary>
        /// 邮箱
        /// </summary>
        public string UserEmail { get; set; } = string.Empty; 
        /// <summary>
        /// 电话
        /// </summary>
        public string UserPhone { get; set; } = string.Empty;

        /// <summary>
        /// 性别：0表示男，1表示女
        /// </summary>
        public int Gender { get; set; } = 0; 
        
        public int Age { get; set; }
        
        //用户权限
        public UserRole Role { get; set; } = UserRole.NormalUser;

        /// <summary>
        /// 用户头像，存储头像路径
        /// </summary>
        public string AvatarUrl { get; set; } = string.Empty; 
    }
}
