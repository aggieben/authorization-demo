using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication.AspNetCore.Authorization;

namespace WebApplication.Models.ManageViewModels
{
    public class ManagePermissionsViewModel
    {
        public ICollection<Permission> Permissions { get; set; }
        public IEnumerable<SelectListItem> PermissionSelectItems { get; set; }
    }
}