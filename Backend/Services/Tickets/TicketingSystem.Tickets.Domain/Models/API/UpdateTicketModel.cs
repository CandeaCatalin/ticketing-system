using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSystem.Tickets.Domain.Models.API
{
    public class UpdateTicketModel
    {
        public int Id { get; set; }
        public int TicketTypeId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public int ServiceTypeId { get; set; }
        public int StatusId { get; set; }
        public int PriorityId { get; set; }
    }
}
