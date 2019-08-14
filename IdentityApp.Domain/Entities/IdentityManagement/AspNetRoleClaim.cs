using Microsoft.AspNetCore.Identity;

namespace IdentityApp.Domain.Entities.IdentityManagement
{
    public class AspNetRoleClaim: IdentityRoleClaim<int>
    {
        public virtual AspNetRole Role { get; set; }
    }
}
