namespace Entity.vo;

public class UserInfoVo
{
    public int Id { get; set; }
    /// <summary>
    /// 用户名
    /// </summary>
    public string? UserName { get; set; }

    /// <summary>
    /// 邮箱
    /// </summary>
    public string? UserEmail { get; set; }
    /// <summary>
    /// 电话
    /// </summary>
    public string? UserPhone { get; set; }


    /// <summary>
    /// 用户头像，存储头像路径
    /// </summary>
    public string? PhotoUrl { get; set; }
}