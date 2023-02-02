using Microsoft.AspNetCore.Identity;

namespace Sidebar.Models.IdentityUsers
{
    public class AppUser : IdentityUser
    {

        public Candidate Candidate { get; set; }
    }
}
