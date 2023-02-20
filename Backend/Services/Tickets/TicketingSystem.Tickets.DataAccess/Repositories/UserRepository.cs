using TicketingSystem.Tickets.Application.Abstractions;
using TicketingSystem.Tickets.DataAccess.Database;
using TicketingSystem.Tickets.Domain.Models;

namespace TicketingSystem.Tickets.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TicketDbContext _ticketDbContext;

        public UserRepository(TicketDbContext ticketDbContext) {
            _ticketDbContext = ticketDbContext;
        }
        public async Task AddUserInDb(Guid userId, string userName)
        {
            
            if(await GetUserFromDb(userId) is null)
            {
                var newUser = new User { Id = userId, Name = userName };
                await _ticketDbContext.Users.AddAsync(newUser);
                _ticketDbContext.SaveChanges();
            }
            
        }

        

        public async Task<User?> GetUserFromDb(Guid userId)
        {
            var userFromDb = await _ticketDbContext.Users.FindAsync(userId);
            return userFromDb;
        }

       
    }
}
