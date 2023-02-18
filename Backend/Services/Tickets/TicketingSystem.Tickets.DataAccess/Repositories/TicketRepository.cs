using TicketingSystem.Exceptions;
using TicketingSystem.Tickets.Application.Abstractions;
using TicketingSystem.Tickets.DataAccess.Database;
using TicketingSystem.Tickets.Domain.Models;
using TicketingSystem.Tickets.Domain.Models.API;

namespace TicketingSystem.Tickets.DataAccess.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly TicketDbContext _ticketDbContext;

        public TicketRepository(TicketDbContext ticketDbContext)
        {
            _ticketDbContext = ticketDbContext;
        }
        public async Task CreateTicket(CreateTicketModel model)
        {
            var userIdAsGuid = new Guid(model.UserId);
            User user = await GetUserFromDbAsync(userIdAsGuid);
            TicketStatus ticketStatus =await GetTicketStatusFromDbAsync(model.StatusId);
            TicketType ticketType = await GetTicketTypeFromDbAsync(model.TicketTypeId);
            TicketServiceType ticketServiceType = await GetTicketServiceTypeFromDbAsync(model.ServiceTypeId);
            var newTicketToAdd = new Ticket
            {
                Desciption = model.Description,
                Subject = model.Subject,
                TicketType = ticketType,
                Status = ticketStatus,
                ServiceType = ticketServiceType,
                Opened = DateTime.Now,
            };
            await _ticketDbContext.AddAsync(newTicketToAdd);
            await _ticketDbContext.SaveChangesAsync();
        }

        private async Task<TicketServiceType> GetTicketServiceTypeFromDbAsync(int serviceTypeId)
        {
            var ticketServiceTypeFromDb = await _ticketDbContext.TicketServiceTypes.FindAsync(serviceTypeId);
            if (ticketServiceTypeFromDb is null)
            {
                throw new ValidationException("TicketService does not exist!");

            }
            return ticketServiceTypeFromDb;
        }

        private async Task<TicketType> GetTicketTypeFromDbAsync(int ticketTypeId)
        {
            var ticketTypeFromDb = await _ticketDbContext.TicketTypes.FindAsync(ticketTypeId);
            if (ticketTypeFromDb is null)
            {
                throw new ValidationException("TicketType does not exist!");
            }
            return ticketTypeFromDb;
        }

        private async Task<TicketStatus> GetTicketStatusFromDbAsync(int statusId)
        {
            var ticketStatusFromDb = await _ticketDbContext.TicketStatuses.FindAsync(statusId);
            if (ticketStatusFromDb is null)
            {
                throw new ValidationException("TicketStatus does not exist!");
            }
            return ticketStatusFromDb;
        }

        private async Task<User> GetUserFromDbAsync(Guid userIdAsGuid)
        {
            var userFromDb = await _ticketDbContext.Users.FindAsync(userIdAsGuid);
            if (userFromDb is null)
            {
                throw new ValidationException("User does not exist!");
            }
            return userFromDb;
        }
    }
}
