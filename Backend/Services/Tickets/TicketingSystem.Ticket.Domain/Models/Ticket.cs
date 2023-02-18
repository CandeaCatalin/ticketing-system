namespace TicketingSystem.Ticket.Domain.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public TicketType TicketType { get; set; } = new TicketType();
        public User User { get; set; } = new User();
        public ServiceType ServiceType { get; set; } = new ServiceType();
        public Status Status { get; set; } = new Status();
        public DateTime Opened { get; set; }
        public DateTime Closed { get; set; }
    }
}
