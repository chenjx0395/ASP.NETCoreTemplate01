namespace Entity.Request.User;

public class RegistrationForm
{
    /// <summary>
    /// 用户名
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// 密码
    /// </summary>
    public string PasswordHash { get; set; } = string.Empty;

    public string ConfirmPasswordHash { get; set; } = string.Empty;



    /// <summary>
    /// 邮箱
    /// </summary>
    public string UserEmail { get; set; } = string.Empty;



    /// <summary>
    /// 用户头像，存储头像路径
    /// </summary>
    public string AvatarUrl { get; set; } = string.Empty;

    public int Code { get; set; } // 验证码
    
}