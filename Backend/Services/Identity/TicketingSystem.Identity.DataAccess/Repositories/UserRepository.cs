using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using TicketingSystem.Exceptions;
using TicketingSystem.Identity.Application.Abstractions;
using TicketingSystem.Identity.Domain.Models;
using TicketingSystem.Identity.Domain.Models.API;

namespace TicketingSystem.Identity.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private const string SECRET_KEY = "nVsc7jp9Kv1pnyqLyeyYsbQNyK7RjLuYh2erLN0VMb7KMuTR1RkHvH32AHeXKxJa";
        public UserRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task Register(RegisterModel model)
        {
            if (model.Email is not null && model.Password is not null)
            {
                if (!IsValidEmail(model.Email))
                {
                    throw new ValidationException("Email is invalid!");
                }
                if (!IsValidPassword(model.Password))
                {
                    throw new ValidationException("Password is not correct!");
                }
                var existingUser = await GetUserByEmailAsync(model.Email);
                if (existingUser is not null)
                {
                    throw new ValidationException("User already exists");
                }
                CheckUserName(model.FirstName, model.LastName);
                var newUser = new User()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    EmailConfirmed = true,
                    UserName = model.Email
                };
                await _userManager.CreateAsync(newUser, model.Password);
               
            }
        }

        private bool IsValidPassword(string password)
        {
            return password.Length > 8;
        }

        private async Task<User?> GetUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user;
        }
        private bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        private void CheckUserName(string? FirstName, string? LastName)
        {
            if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName))
            {
                throw new ValidationException("Invalid first or last name!");
            }
        }

        public async Task<string> Login(LoginModel model)
        {
            CheckCredentialsForLogin(model);
            var existingUser = await GetUserByEmailAsync(model.Email);
            if (existingUser is null)
            {
                throw new ValidationException("Invalid credentials!");
            }
            await CheckIfPwdsMatchesAsync(existingUser, model.Password);
            var tokenAsString = GenerateToken(existingUser);
            return tokenAsString;
           

        }

        private string GenerateToken(User existingUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var claims = GenerateClaims(existingUser);
            var tokenDescriptor = GenerateTokenDescriptor(claims);
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private SecurityTokenDescriptor GenerateTokenDescriptor(List<Claim> claims)
        {
            var key = Encoding.ASCII.GetBytes(SECRET_KEY);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                            SecurityAlgorithms.HmacSha256Signature)
            };
            return tokenDescriptor;
        }
        private List<Claim> GenerateClaims(User existingUser)
        {
            var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, existingUser.Id),
                    new Claim(JwtRegisteredClaimNames.Email, existingUser.Email),
                    new Claim(ClaimTypes.Name, existingUser.FirstName + " " + existingUser.LastName)
                };
            return claims;
        }

        private async Task CheckIfPwdsMatchesAsync(User existingUser, string password)
        {
            var isValidPassword = await _userManager.CheckPasswordAsync(existingUser, password);
            if (!isValidPassword)
                throw new ValidationException("Invalid credentials!");
        }

        private void CheckCredentialsForLogin(LoginModel model)
        {
            if (model.Email is null || !IsValidEmail(model.Email) || string.IsNullOrWhiteSpace(model.Password))
                throw new ValidationException("Invalid Credentials!");
        }
    }
}
