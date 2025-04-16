using System;
using Microsoft.AspNetCore.Identity;

namespace BookYourShow.Application.DTOs;

public class UserDTO
{

    public string? FullName { get; set; } = string.Empty;
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation property (optional)
    public ICollection<UserRoleDTO>? UserRolesDTO { get; set; } = new List<UserRoleDTO>();
}
