using System;
using Microsoft.AspNetCore.Identity;

namespace BookYourShow.Domain;

public class User : IdentityUser
{
    public string FullName { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation property (optional)
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

}
