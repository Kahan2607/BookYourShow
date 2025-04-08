using System;
using Microsoft.AspNetCore.Identity;

namespace BookYourShow.Domain;

public class Role : IdentityRole
{
    public string Description { get; set; } = string.Empty;

    // Navigation property (optional)
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
