using System;
using AutoMapper;
using BookYourShow.Domain;

namespace BookYourShow.Application.DTOs;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, RegisterUserDTO>().ReverseMap();
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<UserRole, UserRoleDTO>().ReverseMap();
        CreateMap<Role, RoleDTO>().ReverseMap();
    }
}

