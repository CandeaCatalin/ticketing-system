using TicketingSystem.Identity.Domain.Models.API;

namespace TicketingSystem.Identity.Application.Abstractions
{
    public interface IUserRepository
    {
        public Task<string> Login(LoginModel model);
         public Task Register(RegisterModel model);
    }
}
