using System;
using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using BookYourShow.Application.Abstractions.Authentication;
using BookYourShow.Application.DTOs;
using BookYourShow.Domain;
using BookYourShow.Infrastructure.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BookYourShow.Infrastructure.Services;

public class AuthService : IAuthService
{
    // private readonly UserManager<User> _userManager;
    private readonly IJWTTokenGenerator _jWTTokenGenerator;
    private readonly IAuthRepository _authRepository;
    private readonly IMapper _mapper;
    public AuthService(IJWTTokenGenerator jwtTokenGenerator, IAuthRepository authRepository, IMapper mapper)
    {
        _jWTTokenGenerator = jwtTokenGenerator;
        _authRepository = authRepository;
        _mapper = mapper;
    }

    public async Task<string> RegisterAsync(RegisterUserDTO registerUserDTO)
    {
        var user = _mapper.Map<User>(registerUserDTO);
        var result = _authRepository.RegisterAsync(user, registerUserDTO.Email);

        await _authRepository.AddRoleAsync(user);

        var roles = await _authRepository.GetRoleAsync(user);

        return _jWTTokenGenerator.GenerateToken(user, roles);
    }


}
