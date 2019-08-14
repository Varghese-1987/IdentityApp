using Microsoft.AspNetCore.Identity;

namespace IdentityApp.Domain.Entities.IdentityManagement
{
   public  class AspNetUserRole: IdentityUserRole<int>
    {
        public virtual AspNetUser User { get; set; }
        public virtual AspNetRole Role { get; set; }
    }
}
