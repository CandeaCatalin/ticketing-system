namespace TicketingSystem.Tickets.Domain.Models.API
{
    public class CreateTicketModel
    {
        public int TicketTypeId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public Guid? UserId { get; set; }
        public string UserName { get; set; }    
        public string CustomerName { get; set; }    
        public int ServiceTypeId { get; set; }
        public int StatusId { get; set; }
        public int PriorityId { get; set; }
    }
}
