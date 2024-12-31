using Microsoft.AspNetCore.Identity;
using WoodManagementSystem.Domain.Common;

namespace WoodManagementSystem.Domain.Entities
{
    public class User : IdentityUser<int>,IEntityBase
    {
        public string? FullName { get; set; }
        public string? CompanyName { get; set; }
        public string? Address { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public string? RefreshPasswordCode { get; set; }
        public DateTime RefreshPasswordCodeExpiryTime { get; set; }
    }
}
