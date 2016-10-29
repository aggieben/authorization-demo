using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebApplication.AspNetCore.Authorization;
using WebApplication.Data;

namespace WebApplication.AspNetCore.Identity
{
    public class DemoUserManager<TUser> : UserManager<TUser>
        where TUser : class
    {
        protected ApplicationDbContext DbContext { get; }

        public DemoUserManager(
            IUserStore<TUser> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<TUser> passwordHasher,
            IEnumerable<IUserValidator<TUser>> userValidators,
            IEnumerable<IPasswordValidator<TUser>> passwordValidators,
            ILookupNormalizer keyNormalizer, 
            IdentityErrorDescriber errors,
            IServiceProvider serviceProvider,
            ApplicationDbContext dbContext,
            ILogger<UserManager<TUser>> logger
        ) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, serviceProvider, logger) 
        {
            DbContext = dbContext;
        }

        public virtual async Task<IEnumerable<Permission>> GetUserPermissionsAsync(TUser user)
        {
            var id = await GetUserIdAsync(user);
            return await DbContext.UserPermissions
                .Where(up => up.ApplicationUserId == id)
                .Select(up => up.Permission)
                .ToListAsync();
        } 
    }
}