using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace IdentityApp.Domain.Entities.IdentityManagement
{
    public class AspNetRole:IdentityRole<int>
    {
        public virtual ICollection<AspNetUserRole> UserRoles { get; set; }
        public virtual ICollection<AspNetRoleClaim> RoleClaims { get; set; }

    }
}
