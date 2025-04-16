using System;
using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using BookYourShow.Application.Abstractions.Authentication;
using BookYourShow.Application.DTOs;
using BookYourShow.Application.Results;
using BookYourShow.Domain;
using BookYourShow.Infrastructure.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Update;

namespace BookYourShow.Infrastructure.Services;

public class AuthService : IAuthService
{
    // private readonly UserManager<User> _userManager;
    private readonly IJwtTokenGenerator _jWTTokenGenerator;
    private readonly IAuthRepository _authRepository;
    private readonly IMapper _mapper;

    public AuthService(IJwtTokenGenerator jwtTokenGenerator, IAuthRepository authRepository, IMapper mapper)
    {
        _jWTTokenGenerator = jwtTokenGenerator;
        _authRepository = authRepository;
        _mapper = mapper;
    }

    public async Task<Result<RegisterUserDTO>> RegisterAsync(RegisterUserDTO registerUserDTO)
    {
        // 1. Check if user already exists (avoid duplicates)
        // if (await _authRepository.UserExistsAsync(registerUserDTO.Email))
        // {
        //     return Result<RegisterUserDTO>.Failure("User with this email already exists.");
        // }

        // 2. Map DTO to User entity
        var user = _mapper.Map<User>(registerUserDTO);

        // 3. Register the user (e.g., hash password, save to DB)
        var registrationResult = await _authRepository.RegisterAsync(user, registerUserDTO.Password);
        if (!registrationResult.Succeeded)
        {
            return Result<RegisterUserDTO>.Failure("User registration failed: " + string.Join(", ", registrationResult.Errors));
        }

        // 4. Assign a default role (e.g., "User")
        var roleResult = await _authRepository.AddRoleAsync(user);
        if (!roleResult.Succeeded)
        {
            return Result<RegisterUserDTO>.Failure("Role assignment failed: " + string.Join(", ", roleResult.Errors));
        }

        // 5. Return the registered user's DTO (without sensitive data)
        return Result<RegisterUserDTO>.Success(new RegisterUserDTO
        {
            Id = user.Id,
            Email = user.Email,

            // Include other non-sensitive fields
        });
    }


}
