using TicketingSystem.Tickets.Domain.Models.API;

namespace TicketingSystem.Tickets.Application.Abstractions
{
    public interface ITicketRepository
    {
        public Task CreateTicket(CreateTicketModel model);
    }
}
