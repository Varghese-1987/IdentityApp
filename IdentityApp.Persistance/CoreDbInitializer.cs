using System.Linq;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

using IdentityApp.Domain.Entities.IdentityManagement;
using IdentityApp.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace IdentityApp.Persistance
{
    public static class CoreDbInitializer
    {
        public static void Initialize(IServiceCollection serviceDescriptors)
        {

            var serviceProvider = serviceDescriptors.BuildServiceProvider();
            using (CoreDbContext coreContext = (CoreDbContext)serviceProvider.GetService(typeof(CoreDbContext)))
            {
                coreContext.Database.Migrate();
                var userManager = serviceProvider.GetService<UserManager<AspNetUser>>();
                if (!coreContext.AspNetUsers.Any(e => e.UserName.Equals("admin@admin.com")))
                {
                    var user = new AspNetUser { UserName = "admin@admin.com", EmailConfirmed = true, Email = "admin@admin.com" };
                    IdentityResult result = userManager.CreateAsync(user, "DotNetDemo@1").Result;
                }

            }
        }
    }
}
