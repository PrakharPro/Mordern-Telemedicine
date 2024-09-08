using Microsoft.AspNetCore.Identity;

namespace Telemedicine_AuthAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
