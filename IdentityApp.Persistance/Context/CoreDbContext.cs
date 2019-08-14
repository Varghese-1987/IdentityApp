using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using IdentityApp.Domain.Entities.IdentityManagement;
using IdentityApp.Persistance.EntityConfigurations.IdentityConfigurations;

namespace IdentityApp.Persistance.Context
{
    public class CoreDbContext : IdentityDbContext<AspNetUser, AspNetRole, int, AspNetUserClaim, AspNetUserRole, AspNetUserLogin, AspNetRoleClaim, AspNetUserToken>

    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options)
        {

        }

        public DbSet<AspNetUser> AspNetUsers { get; set; }
        public DbSet<AspNetRole> AspNetRoles { get; set; }
        public DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public DbSet<AspNetUserToken> AspNetUserToken { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            IdentityConfigurationHelper.IdentityConfigurations(builder);
        }

    }
}
