using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WalkToFlayApi.Models.Output;

namespace WalkToFlayApi.Infrastructure.ActionFilter
{
    /// <summary>
    /// 統一StatusCodes.Status200OK輸出格式
    /// </summary>
    public class SuccessMessageActionFilter :  IAsyncActionFilter, IFilterMetadata
    {

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            ActionExecutedContext executedContext = await next();
            IActionResult result2 = executedContext.Result;
            ObjectResult result = result2 as ObjectResult;
            if(result != null && !(result.Value is HttpResponseMessage))
            {
                ApiVersionAttribute apiVersion = (ApiVersionAttribute)null;
                var actionDescriptor = context.ActionDescriptor;
                var controllerActionDescriptor = actionDescriptor as ControllerActionDescriptor;
                if(controllerActionDescriptor != null)
                {
                    apiVersion = (ApiVersionAttribute)controllerActionDescriptor.MethodInfo.GetCustomAttributes(typeof(ApiVersionAttribute), false).FirstOrDefault();
                    apiVersion = apiVersion ?? (ApiVersionAttribute)controllerActionDescriptor.ControllerTypeInfo.GetCustomAttributes(typeof(ApiVersionAttribute), true).FirstOrDefault();
                }
                var responseModel = new SuccessOutputModel<object>()
                {
                    Id = Guid.NewGuid(),
                    ApiVersion = apiVersion is null ? "1.0" : apiVersion.Versions.FirstOrDefault().ToString(),
                    Method = $"{context.HttpContext.Request.Path}",
                    Data = result.Value
                };
                
                executedContext.Result = new ObjectResult(responseModel)
                {
                    StatusCode = 200
                };
            }
        }
    }
}
