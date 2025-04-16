using BookYourShow.Application.Abstractions.Authentication;
using BookYourShow.Application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookYourShow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public UserAuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterUserDTO registerUserDTO)
        {
            var result = await _authService.RegisterAsync(registerUserDTO);

            if (!result.IsSuccess)
                return BadRequest(result.Error); // HTTP 400


            // Note. Will create this when I will create a method of GetUser() here
            // return CreatedAtAction(
            //     nameof(GetUser),
            //     new { id = result.Data.Id },
            //     result.Data // HTTP 201 + DTO
            // );
            return Ok();
        }
    }
}
