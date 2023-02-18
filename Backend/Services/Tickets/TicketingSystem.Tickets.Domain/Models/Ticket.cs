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
        public User User { get; set; } = new User();
        public TicketServiceType ServiceType { get; set; } = new TicketServiceType();
        public string Subject { get; set; } = "";
        public string Desciption { get; set; } = "";
        public TicketStatus Status { get; set; } = new TicketStatus();
        public DateTime Opened { get; set; }
        public DateTime Closed { get; set; }
    }
}
