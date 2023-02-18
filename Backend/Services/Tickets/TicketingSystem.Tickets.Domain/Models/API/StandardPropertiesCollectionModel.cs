namespace TicketingSystem.Tickets.Domain.Models.API
{
    public class StandardPropertiesCollectionModel
    {
        public List<TicketPriority> Priorities { get; set; } = new List<TicketPriority>();
        public List<TicketServiceType> ServiceTypes { get; set; } = new List<TicketServiceType>();
        public List<TicketStatus> Statuses { get; set; } = new List<TicketStatus>();
        public List<TicketType> TicketTypes { get; set; } = new List<TicketType>();

    }
}
