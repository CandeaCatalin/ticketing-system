using Microsoft.AspNetCore.Identity;

namespace TicketingSystem.Identity.Domain.Models
{
    public class User : IdentityUser
    {
        public DateTime CreatedAtTimeUtc { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
