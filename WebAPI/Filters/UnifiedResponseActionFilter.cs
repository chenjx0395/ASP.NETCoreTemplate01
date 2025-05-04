using Entity.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPI.Filters;

public class UnifiedResponseActionFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext actionContext, ActionExecutionDelegate next)
    {
        var resultContext = await next();

        if (resultContext.Exception != null)
        {
            // 异常处理应该由 ExceptionHandler 处理，这里跳过
            return;
        }

        if (resultContext.Result is ObjectResult objectResult)
        {
            if (objectResult.Value is ApiResponse<object>)
                return;

            var statusCode = objectResult.StatusCode ?? 200;

            var response = new ApiResponse<object>
            {
                Code = statusCode,
                Message = GetMessageFromStatusCode(statusCode),
                Data = objectResult.Value
            };

            resultContext.Result = new JsonResult(response)
            {
                StatusCode = statusCode
            };
        }
        else if (resultContext.Result is StatusCodeResult statusCodeResult)
        {
            var statusCode = statusCodeResult.StatusCode;

            var response = new ApiResponse<object>
            {
                Code = statusCode,
                Message = GetMessageFromStatusCode(statusCode),
                Data = null
            };

            resultContext.Result = new JsonResult(response)
            {
                StatusCode = statusCode
            };
        }
    }

    private string GetMessageFromStatusCode(int statusCode)
    {
        return statusCode switch
        {
            200 => "成功",
            201 => "已创建",
            400 => "请求错误",
            401 => "未授权",
            403 => "禁止访问",
            404 => "未找到",
            500 => "服务器错误",
            _ => "未知状态"
        };
    }
}