using TicketingSystem.Tickets.Domain.Models;
using TicketingSystem.Tickets.Domain.Models.API;

namespace TicketingSystem.Tickets.Application.Abstractions
{
    public interface ITicketRepository
    {
        public Task CreateTicket(CreateTicketModel model);
        public Task UpdateTicket(UpdateTicketModel model);
        public Task DeleteTicket(DeleteTicketModel model);
        public Task CloseTicket(CloseTicketModel model);
        public Task<List<Ticket>> GetTicketsForUser(Guid userId);
        public Task<StandardPropertiesCollectionModel> GetStandardProperties();
    }
}
