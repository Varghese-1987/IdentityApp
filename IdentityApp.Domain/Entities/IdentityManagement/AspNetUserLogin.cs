using Microsoft.AspNetCore.Identity;

namespace IdentityApp.Domain.Entities.IdentityManagement
{
    public class AspNetUserLogin: IdentityUserLogin<int>
    {
        public virtual AspNetUser User { get; set; }
    }
}
