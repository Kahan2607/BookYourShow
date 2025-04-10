using System;
using BookYourShow.Application.DTOs;

namespace BookYourShow.Application.Abstractions.Authentication;

public interface IAuthService
{
    Task<string> RegisterAsync(RegisterUserDTO registerUserDTO);
    // Task<string> LoginAsync(string email, string password);


}
