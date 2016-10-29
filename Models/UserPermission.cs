using WebApplication.AspNetCore.Authorization;

namespace WebApplication.Models
{
    public class UserPermission
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public Permission Permission { get; set; }
    }
}