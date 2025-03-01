using Microsoft.AspNetCore.Identity;

namespace InventoryAPI.Models
{
    public class AppUser : IdentityUser
    {
        public string? FullName { get; set; }
    }
}
