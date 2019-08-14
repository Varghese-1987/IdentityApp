using Microsoft.AspNetCore.Identity;

namespace IdentityApp.Domain.Entities.IdentityManagement
{
    public  class AspNetUserToken: IdentityUserToken<int>
    {
        public virtual AspNetUser User { get; set; }
    }
}
