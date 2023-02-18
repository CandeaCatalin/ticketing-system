using TicketingSystem.Tickets.Domain.Models;

namespace TicketingSystem.Tickets.Application.Abstractions
{
    public interface IUserRepository
    {
        public Task AddUserInDb(string userId, string userName);
        public Task<User?> GetUserFromDb(Guid userId);
    }
}
