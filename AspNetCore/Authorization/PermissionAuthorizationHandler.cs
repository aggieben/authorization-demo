using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using WebApplication.AspNetCore.Identity;
using WebApplication.Models;

namespace WebApplication.AspNetCore.Authorization
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionAuthorizationRequirement>
    {
        private readonly ILogger _logger;
        private readonly DemoUserManager<ApplicationUser> _userManager;

        public PermissionAuthorizationHandler(ILogger<PermissionAuthorizationHandler> logger, DemoUserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionAuthorizationRequirement requirement)
        {
            var user = await _userManager.GetUserAsync(context.User);
            var currentUserPermissions = await _userManager.GetUserPermissionsAsync(user);

            var authorized = requirement.RequiredPermissions.AsParallel().All(rp => currentUserPermissions.Contains(rp)); // TODO: load permissions into context.User 
            if (authorized) context.Succeed(requirement);
        }
    }
}