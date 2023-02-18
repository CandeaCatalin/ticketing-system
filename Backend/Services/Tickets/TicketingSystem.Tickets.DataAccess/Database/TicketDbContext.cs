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
        public DbSet<TicketType> TicketTypes { get; set; } 
        public DbSet<TicketStatus> TicketStatuses{ get; set; } 
        public DbSet<TicketServiceType> TicketServiceTypes{ get; set; } 
        public DbSet<TicketPriority> TicketPriorities { get; set; } 
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AddPriorityDefaultData( modelBuilder);
            AddStatusDefaultData( modelBuilder);
            AddTicketTypeDefaultData( modelBuilder);
            AddTicketServiceTypeDefaultData( modelBuilder);
           
        }

        private void AddTicketServiceTypeDefaultData(ModelBuilder modelBuilder)
        {
            var ticketServiceTypeDefaultData = new List<TicketServiceType>()
            {
                new TicketServiceType{ Id = 1, Name="Service type 1"},
                new TicketServiceType{ Id = 2, Name="Service type 2"},
                new TicketServiceType{ Id = 3, Name="Service type 3"},
            };
            modelBuilder.Entity<TicketServiceType>().HasData(ticketServiceTypeDefaultData);
        }

        private void AddTicketTypeDefaultData( ModelBuilder modelBuilder)
        {
            var ticketTypeDefaultData = new List<TicketType>()
            {
                new TicketType{ Id = 1, Name="Bug"},
                new TicketType{ Id = 2, Name="Feature Request"},
                new TicketType{ Id = 3, Name="How To"},
                new TicketType{ Id = 4, Name="Technical Issue"},
                new TicketType{ Id = 5, Name="Cancellation"},
                new TicketType{ Id = 6, Name="Sales Question"},
            };
            modelBuilder.Entity<TicketType>().HasData(ticketTypeDefaultData);

        }

        private void AddStatusDefaultData(ModelBuilder modelBuilder)
        {
            var statusDefaultData = new List<TicketStatus>()
            {
                new TicketStatus{ Id = 1, Name="Closed"},
                new TicketStatus{ Id = 2, Name="In progress"},
                new TicketStatus{ Id = 3, Name="Open"},
            };
            modelBuilder.Entity<TicketStatus>().HasData(statusDefaultData);

        }

        private void AddPriorityDefaultData(ModelBuilder modelBuilder)
        {
            var priorityDefaultData = new List<TicketPriority>()
            {
                new TicketPriority{ Id = 1, Name="LOW"},
                new TicketPriority{ Id = 2, Name="MEDIUM"},
                new TicketPriority{ Id = 3, Name="HIGH"},
            };
            modelBuilder.Entity<TicketPriority>().HasData(priorityDefaultData);

        }
    }
}
