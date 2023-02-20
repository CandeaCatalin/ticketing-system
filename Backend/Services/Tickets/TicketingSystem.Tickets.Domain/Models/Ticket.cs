using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TicketingSystem.Tickets.Domain.Models
{
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public TicketType TicketType { get; set; } = new TicketType();
        public User UserWhoCreated { get; set; } = new User();
        public TicketServiceType ServiceType { get; set; } = new TicketServiceType();
        public string Subject { get; set; } = "";
        public string Description { get; set; } = "";
        public TicketStatus Status { get; set; } = new TicketStatus();
        public DateTime Opened { get; set; }
        public string CustomerName { get; set; }
        public DateTime Closed { get; set; }
        public TicketPriority Priority { get; set; }
    }
}
