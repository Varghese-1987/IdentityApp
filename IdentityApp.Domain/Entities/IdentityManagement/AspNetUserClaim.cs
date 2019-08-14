using Microsoft.AspNetCore.Identity;

namespace IdentityApp.Domain.Entities.IdentityManagement
{
    public  class AspNetUserClaim: IdentityUserClaim<int>
    {
        public virtual AspNetUser User { get; set; }
    }
}
