using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WalkToFlayApi.Models.Output;

namespace WalkToFlayApi.Infrastructure.ActionFilter
{
    /// <summary>
    /// Exception過濾
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Filters.IAsyncExceptionFilter" />
    public class ExceptionFilter : IAsyncExceptionFilter
    {
        public async Task OnExceptionAsync(ExceptionContext context)
        {
            ApiVersionAttribute apiVersion = (ApiVersionAttribute)null;
            var actionDescriptor = context.ActionDescriptor;
            var controllerActionDescriptor = actionDescriptor as ControllerActionDescriptor;
            if (controllerActionDescriptor != null)
            {
                apiVersion = (ApiVersionAttribute)controllerActionDescriptor.MethodInfo.GetCustomAttributes(typeof(ApiVersionAttribute), false).FirstOrDefault();
                apiVersion = apiVersion ?? (ApiVersionAttribute)controllerActionDescriptor.ControllerTypeInfo.GetCustomAttributes(typeof(ApiVersionAttribute), true).FirstOrDefault();
            }
            var response = new FailOutputModel
            {
                Id = Guid.NewGuid(),
                Method = $"{context.HttpContext.Request.Path}.{context.HttpContext.Request.Method}",
                ApiVersion = apiVersion is null ? "1.0" : apiVersion.Versions.FirstOrDefault().ToString(),
                Error = new FailInformation
                {
                    Domain = "WalkToFly",
                    Message = context.Exception.Message,
                    Description = context.Exception.ToString()
                }
            };

            context.Result = new ObjectResult(response)
            {
                // 500
                StatusCode = (int)HttpStatusCode.InternalServerError
            };

            // Exceptinon Filter只在ExceptionHandled=false時觸發
            // 所以處理完Exception要標記true表示已處理
            context.ExceptionHandled = true;
        }
    }
}
