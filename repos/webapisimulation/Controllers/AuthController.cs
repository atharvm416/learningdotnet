using coresimulation.DTOs;
using coresimulation.Models;
using coresimulation.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace webapisimulation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationcreationContext _context;
        private readonly TokenService _tokenService;

        public AuthController(ApplicationcreationContext context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthResponseDto>> Register(RegisterDTO RegisterDTO)
        {
            // Check if user already exists
            if (await _context.Users.AnyAsync(u => u.Email == RegisterDTO.Email))
            {
                return BadRequest(new AuthResponseDto
                {
                    IsSuccess = false,
                    Message = "User already exists"
                });
            }

            // Create password hash (in a real app, use proper hashing like BCrypt)
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(RegisterDTO.Password);

            var user = new User
            {
                Email = RegisterDTO.Email,
                PasswordHash = passwordHash,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                RoleId = int.TryParse(RegisterDTO.RoleId, out var roleId) ? roleId : 2 // Default to role 2 if parsing fails
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new AuthResponseDto
            {
                IsSuccess = true,
                Message = "User registered successfully"
            });
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponseDto>> Login(LoginDto loginDto)
        {
            var user = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Email == loginDto.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
            {
                return Unauthorized(new AuthResponseDto
                {
                    IsSuccess = false,
                    Message = "Invalid email or password"
                });
            }

            // Update last login
            user.LastLogin = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            // Generate JWT token
            var token = _tokenService.GenerateJwtToken(user);

            return Ok(new AuthResponseDto
            {
                IsSuccess = true,
                Message = "Login successful",
                Token = token
            });
        }

    }
}
