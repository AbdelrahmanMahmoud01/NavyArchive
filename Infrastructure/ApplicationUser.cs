using Domain.Entites;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure
{
    public class ApplicationUser : IdentityUser
    {
        public virtual Officer Officer { get; set; }
        public virtual FileDestination Department { get; set; }
    }
}
