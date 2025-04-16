using System;
using BookYourShow.Application.Abstractions.Authentication;
using BookYourShow.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Identity.Client.Extensibility;

namespace BookYourShow.Infrastructure.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly UserManager<User> _userManager;

    public AuthRepository(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IdentityResult> RegisterAsync(User user, string password)
    {
        var registeredUser = new User { Email = user.Email, UserName = user.Email };
        var result = await _userManager.CreateAsync(registeredUser, password);

        if (!result.Succeeded)
        {
            throw new Exception("Registration failed.");
        }
        return result;
    }

    public async Task<IdentityResult> AddRoleAsync(User user)
    {
        return await _userManager.AddToRoleAsync(user, "User");
    }

    public async Task<IList<string>> GetRoleAsync(User user)
    {
        return await _userManager.GetRolesAsync(user);
    }
}

