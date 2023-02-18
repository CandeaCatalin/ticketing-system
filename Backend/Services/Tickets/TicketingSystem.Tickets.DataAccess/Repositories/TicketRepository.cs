using Microsoft.EntityFrameworkCore;
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
        private readonly IUserRepository _userRepository;

        public TicketRepository(TicketDbContext ticketDbContext, IUserRepository userRepository)
        {
            _ticketDbContext = ticketDbContext;
            _userRepository = userRepository;
        }
        public async Task CreateTicket(CreateTicketModel model)
        {
            var userIdAsGuid = new Guid(model.UserId);
            User? user = await GetUserAsync(userIdAsGuid);
            TicketStatus ticketStatus = await GetTicketStatusFromDbAsync(model.StatusId);
            TicketType ticketType = await GetTicketTypeFromDbAsync(model.TicketTypeId);
            TicketServiceType ticketServiceType = await GetTicketServiceTypeFromDbAsync(model.ServiceTypeId);
            TicketPriority priority = await GetPriorityFromDbAsync(model.PriorityId);
            var newTicketToAdd = new Ticket
            {
                Desciption = model.Description,
                Subject = model.Subject,
                TicketType = ticketType,
                UserWhoCreated = user,
                CustomerName = model.CustomerName,
                Status = ticketStatus,
                ServiceType = ticketServiceType,
                Priority = priority,
                Opened = DateTime.Now,
            };
            await _ticketDbContext.AddAsync(newTicketToAdd);
            await _ticketDbContext.SaveChangesAsync();
        }

        private async Task<TicketPriority> GetPriorityFromDbAsync(int priorityId)
        {
            var ticketServiceTypeFromDb = await _ticketDbContext.Priorities.FindAsync(priorityId);
            if (ticketServiceTypeFromDb is null)
            {
                throw new ValidationException("Priority does not exist!");

            }
            return ticketServiceTypeFromDb;
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

        private async Task<User?> GetUserAsync(Guid userIdAsGuid)
        {
            return await _userRepository.GetUserFromDb(userIdAsGuid);

        }

        public async Task DeleteTicket(DeleteTicketModel model)
        {
            var deletedTicket = await GetTicketById(model.Id);
            if (deletedTicket is not null)
            {
                _ticketDbContext.Tickets.Remove(deletedTicket);
                await _ticketDbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Ticket does not exist");
            }
        }
        public async Task<Ticket?> GetTicketById(int id)
        {
            return await _ticketDbContext.Tickets.Include(t => t.TicketType).Include(t => t.ServiceType).Include(t => t.Status).Include(t=>t.Priority).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task UpdateTicket(UpdateTicketModel model)
        {
            var existingTicket =await GetTicketById(model.Id);
            if(existingTicket is null)
            {
                throw new Exception("Ticket does not exist!");
            }
            TicketStatus newTicketStatus = await GetTicketStatusFromDbAsync(model.StatusId);
            TicketType newTicketType = await GetTicketTypeFromDbAsync(model.TicketTypeId);
            TicketServiceType newTicketServiceType = await GetTicketServiceTypeFromDbAsync(model.ServiceTypeId);
            TicketPriority priority = await GetPriorityFromDbAsync(model.PriorityId);
            existingTicket.Status = newTicketStatus;
            existingTicket.ServiceType = newTicketServiceType;
            existingTicket.Priority = priority;
            existingTicket.Subject = model.Subject;
            existingTicket.Desciption = model.Description;
            existingTicket.TicketType = newTicketType;
            _ticketDbContext.Update(existingTicket);
            await _ticketDbContext.SaveChangesAsync();
        }
    }
}
