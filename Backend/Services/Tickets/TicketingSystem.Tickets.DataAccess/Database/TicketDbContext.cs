using Microsoft.EntityFrameworkCore;
using TicketingSystem.Tickets.Domain.Models;

namespace TicketingSystem.Tickets.DataAccess.Database
{
    public class TicketDbContext:DbContext
    {
        public TicketDbContext(DbContextOptions<TicketDbContext> options) : base(options){

        }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; } 
    }
}
