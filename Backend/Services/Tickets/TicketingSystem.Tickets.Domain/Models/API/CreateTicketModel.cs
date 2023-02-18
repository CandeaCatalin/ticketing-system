﻿namespace TicketingSystem.Tickets.Domain.Models.API
{
    public class CreateTicketModel
    {
        public int TicketTypeId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public int ServiceTypeId { get; set; }
        public int StatusId { get; set; }
    }
}
