using Microsoft.AspNetCore.Identity;

namespace WoodManagementSystem.Domain.Entities
{
    public class User : IdentityUser<int>
    {
        public string FullName { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
