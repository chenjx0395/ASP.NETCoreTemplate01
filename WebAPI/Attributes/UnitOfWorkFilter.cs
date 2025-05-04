using Microsoft.AspNetCore.Mvc.Filters;
using Repository.EFCore;

namespace WebAPI.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class UnitOfWorkFilter : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var result = await next();
            // 如果返回结果没有出现异常，则提交DbContext变更
            if (result.Exception != null)
            {
                return;
            }

            // 获取DbContext对象
            if (context.HttpContext.RequestServices.GetService(typeof(MyDbContext)) is not MyDbContext dbContext)
            {
                return;
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
