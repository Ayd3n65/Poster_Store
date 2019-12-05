using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
namespace PosterStore.Models
{
    public class UserRole : IdentityUserRole<int>
    {
        public User User { get; set; }
        public Role Role { get; set; }
        
    }
}