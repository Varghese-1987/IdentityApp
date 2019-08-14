using Microsoft.EntityFrameworkCore;

using IdentityApp.Domain.Entities.IdentityManagement;

namespace IdentityApp.Persistance.EntityConfigurations.IdentityConfigurations
{
    public static class IdentityConfigurationHelper
    {
        public static void IdentityConfigurations(ModelBuilder builder)
        {
            ConfigureUserTable(builder);
            ConfigureRoleClaimTable(builder);
            ConfigureRoleTable(builder);
            ConfigureUserLoginTable(builder);
            ConfigureUserClaimTable(builder);
            ConfigureUserTokenTable(builder);
        }
        #region private methods
        private static void ConfigureUserTable(ModelBuilder builder)
        {
            builder.Entity<AspNetUser>(
                entity =>
                {
                    entity.ToTable("AspNetUsers");

                    entity.Ignore(user => user.FullName);

                    entity.HasMany(user => user.UserRoles)
                        .WithOne(userRole => userRole.User)
                        .HasForeignKey(userRole => userRole.UserId)
                        .IsRequired()
                        .OnDelete(DeleteBehavior.Cascade);

                    entity.HasMany(user => user.Claims)
                        .WithOne()
                        .HasForeignKey(userClaim => userClaim.UserId)
                        .IsRequired()
                        .OnDelete(DeleteBehavior.Cascade);

                    entity.HasMany(user => user.Logins)
                          .WithOne()
                          .HasForeignKey(ul => ul.UserId)
                          .IsRequired()
                          .OnDelete(DeleteBehavior.Cascade);

                    entity.HasMany(user => user.Tokens)
                          .WithOne()
                          .HasForeignKey(ut => ut.UserId)
                          .IsRequired();

                });
        }

        private static void ConfigureRoleClaimTable(ModelBuilder builder)
        {
            builder.Entity<AspNetRoleClaim>(
                entity =>
                {
                    entity.HasKey(roleClaim => roleClaim.Id);
                    entity.ToTable("AspNetRoleClaims");
                });
        }

        private static void ConfigureRoleTable(ModelBuilder builder)
        {
            builder.Entity<AspNetRole>(
                Role =>
                {
                    Role.ToTable("AspNetRoles");
                    Role.HasMany(e => e.UserRoles)
                        .WithOne(e => e.Role)
                        .HasForeignKey(ur => ur.RoleId)
                        .IsRequired();
                    Role.HasMany(e => e.RoleClaims)
                        .WithOne(e => e.Role)
                        .HasForeignKey(rc => rc.RoleId)
                        .IsRequired();
                });
        }

        private static void ConfigureUserLoginTable(ModelBuilder builder)
        {
            builder.Entity<AspNetUserLogin>().ToTable("AspNetUserLogins");
        }

        private static void ConfigureUserClaimTable(ModelBuilder builder)
        {
            builder.Entity<AspNetUserClaim>().ToTable("AspNetUserClaims");
        }

        private static void ConfigureUserTokenTable(ModelBuilder builder)
        {
            builder.Entity<AspNetUserToken>().ToTable("AspNetUserTokens");
        }
        #endregion
    }
}
