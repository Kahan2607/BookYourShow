using System;
using BookYourShow.Domain;
using Microsoft.AspNetCore.Identity;

namespace BookYourShow.Application.DTOs;

public class UserRoleDTO
{
    public UserDTO? User { get; set; }
    public RoleDTO? Role { get; set; }

}
