using System;

namespace BookYourShow.Application.DTOs;

public class RoleDTO
{
    public string? Description { get; set; } = string.Empty;

    // Navigation property (optional)
    public ICollection<UserRoleDTO>? UserRolesDTO { get; set; } = new List<UserRoleDTO>();
}
