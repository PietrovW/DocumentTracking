using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace DocumentTracking.Infrastructure.Data
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public virtual ICollection<IdentityUserClaim<Guid>> Claims { get; set; }
        public virtual ICollection<IdentityUserLogin<Guid>> Logins { get; set; }
        public virtual ICollection<IdentityUserToken<Guid>> Tokens { get; set; }
        public virtual ICollection<IdentityUserRole<Guid>> UserRoles { get; set; }
    }
}
