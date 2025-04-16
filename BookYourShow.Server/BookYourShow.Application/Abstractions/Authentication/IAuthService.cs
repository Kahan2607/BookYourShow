using System;
using BookYourShow.Application.DTOs;
using BookYourShow.Application.Results;

namespace BookYourShow.Application.Abstractions.Authentication;

public interface IAuthService
{
    Task<Result<RegisterUserDTO>> RegisterAsync(RegisterUserDTO registerUserDTO);
    // Task<string> LoginAsync(string email, string password);


}
