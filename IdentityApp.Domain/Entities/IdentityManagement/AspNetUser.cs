using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace IdentityApp.Domain.Entities.IdentityManagement
{
    public class AspNetUser : IdentityUser<int>
    {
        public string FullName => $"{FirstName} {LastName}";
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<AspNetUserRole> UserRoles { get; set; }
        public virtual ICollection<AspNetUserClaim> Claims { get; set; }
        public virtual ICollection<AspNetUserLogin> Logins { get; set; }
        public virtual ICollection<AspNetUserToken> Tokens { get; set; }
    }
}
