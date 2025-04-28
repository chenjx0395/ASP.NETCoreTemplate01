using System.Reflection;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Repository.EFCore;

namespace WebAPI.Filters
{
    public class UnitOfWorkFilter : IAsyncActionFilter
    {
        /*private readonly MyDbContext myDbContext;
        public UnitOfWorkFilter(MyDbContext myDbContext)
        {

            this.myDbContext = myDbContext;
        }*/
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var result = await next();

            //在next方法的后面去处理saveChanges
            if (result.Exception != null)
            {
                return;
            }
            var controllerActionDesc = context.ActionDescriptor as ControllerActionDescriptor;
            if (controllerActionDesc == null)
            {
                return;
            }
            var unitAttr = controllerActionDesc.MethodInfo.GetCustomAttribute(typeof(UnicodeAttribute));
            if (unitAttr == null)
            {
                return;
            }

            var dbContext = context.HttpContext.RequestServices.GetService(typeof(MyDbContext)) as DbContext;
            if (dbContext != null)
            {
                await dbContext.SaveChangesAsync();
            }



        }
    }
}
