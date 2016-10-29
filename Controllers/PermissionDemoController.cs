using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using WebApplication.AspNetCore.Authorization;
using WebApplication.AspNetCore.Mvc.Filters;

namespace WebApplication.Controllers
{
    [Authorize]
    public class PermissionsDemoController : Controller
    {
        [RequiresPermission(Permission.Permission1)]
        public IActionResult TestPermission1()
        {
            return Content("Success!");
        }

        [RequiresPermission(Permission.Permission2)]
        public IActionResult TestPermission2()
        {
            return Content("Success!");
        }

        [RequiresPermission(Permission.Permission1,Permission.Permission2)]
        public IActionResult TestPermission12()
        {
            return Content("Success!");
        }
    }
}