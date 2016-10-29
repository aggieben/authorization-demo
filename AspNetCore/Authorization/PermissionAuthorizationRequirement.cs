using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication.AspNetCore.Authorization
{
    public class PermissionAuthorizationRequirement : IAuthorizationRequirement
    {
        public IEnumerable<Permission> RequiredPermissions { get; }

        public PermissionAuthorizationRequirement(IEnumerable<Permission> requiredPermissions)
        {
            RequiredPermissions = requiredPermissions;
        }
    }
}