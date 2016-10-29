using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

using WebApplication.AspNetCore.Authorization;

namespace WebApplication.AspNetCore.Mvc.Filters
{
    public class RequiresPermissionAttribute : TypeFilterAttribute
    {
        public RequiresPermissionAttribute(params Permission[] permissions) : base(typeof(RequiresPermissionAttributeImpl))
        {
            Arguments = new[] { new PermissionAuthorizationRequirement(permissions) };
        }

        private class RequiresPermissionAttributeImpl : Attribute, IAsyncResourceFilter
        {
            private readonly ILogger _logger;
            private readonly IAuthorizationService _authService;
            private readonly PermissionAuthorizationRequirement _permissionRequirement;

            public RequiresPermissionAttributeImpl(ILogger<RequiresPermissionAttribute> logger, 
                                                   IAuthorizationService authService, 
                                                   PermissionAuthorizationRequirement permissionRequirement)
            {
                _logger = logger;
                _authService = authService;
                _permissionRequirement = permissionRequirement;
            }

            public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
            {
                _logger.LogTrace("Executing RequiresPermissionAttributeImpl filter");

                if (!await _authService.AuthorizeAsync(context.HttpContext.User, context.ActionDescriptor.ToString(), _permissionRequirement))
                {
                    context.Result = new ChallengeResult();
                }
                else
                {
                    await next();
                }
            }
        }
    }
}