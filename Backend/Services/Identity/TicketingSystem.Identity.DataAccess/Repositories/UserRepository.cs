using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TicketingSystem.Identity.Application.Abstractions;
using TicketingSystem.Identity.Application.Exceptions;
using TicketingSystem.Identity.Domain.Models;
using TicketingSystem.Identity.Domain.Models.API;

namespace TicketingSystem.Identity.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        public UserRepository(UserManager<User> userManager) {
            _userManager = userManager;
        }
        
        public async Task Register(RegisterModel model)
        {
            if(model.Email is not null && model.Password is not null)
            {
                if (!IsValidEmail(model.Email))
                {
                    throw new ValidationException("Email is invalid!");
                }
                var existingUser =await GetUserByEmailAsync(model.Email);
                if(existingUser is not null) 
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
            if(string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName)) 
            {
                throw new ValidationException("Invalid first or last name!");
            }
        }
    }
}
