using System;
using BookYourShow.Domain;

namespace BookYourShow.Application.Abstractions.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user, IList<string> Role);
}
