using System;
using BookYourShow.Domain;
using Microsoft.AspNetCore.Identity;

namespace BookYourShow.Application.Abstractions.Authentication;

public interface IAuthRepository
{
    public Task<IdentityResult> RegisterAsync(User user, string password);
    // Task LoginAsync(string email, string password);
    public Task AddRoleAsync(User user);
    public Task<IList<string>> GetRoleAsync(User user);
}
