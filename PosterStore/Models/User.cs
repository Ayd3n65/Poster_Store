using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace PosterStore.Models
{
    public class User : IdentityUser<int>
    {
        public string Gender {get;set;}
        public int Age { get; set; }
        public ICollection<UserRole> UserRoles {get; set;}

    }
}