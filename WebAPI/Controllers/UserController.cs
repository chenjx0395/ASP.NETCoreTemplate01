using AutoMapper;
using Entity.model;
using Entity.Request.User;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using WebAPI.Attributes;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class UserController(
    IMapper mapper,
    IUserInfoService userInfoService
    ) : ControllerBase
{

    [HttpPost]
    [UnitOfWorkFilter]
    public async Task<IActionResult> Register([FromBody] RegistrationForm registrationForm)
    {
        //TODO 校验参数
        //TODO 校验邮箱验证码
        //新增用户
        var userInfo = mapper.Map<UserInfo>(registrationForm);
        if (!await userInfoService.AddEntityAsync(userInfo))
        {
            return BadRequest();
        }
        return Ok();
    }
    
}