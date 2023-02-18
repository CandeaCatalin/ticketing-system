using Microsoft.EntityFrameworkCore;
using TicketingSystem.Tickets.DataAccess.Database;
using TicketingSystem.Tickets.Domain.Models;

namespace TicketingSystem.Tickets.TicketRepository
{
    public class TicketRepositoryTests
    {
        [Fact]
        public void ShouldCreateTicket()
        {
            var dbOptions = CreateDbContext();
            CreateTicketModel newTicketCreated = new CreateTicketModel()
            {
                TicketTypeId = 1,
                Subject ="Test for creating tickets",
                Description ="Dummy description",
                UserId = "76d2409e-3ddf-493a-b4d4-c65e8e0fa8c0",
                ServiceTypeId = 1,
                StatusId = 1
            };
            using (var context = new TicketDbContext(dbOptions))
            {
                var service = new TicketRepository(context);
                service.CreateTicket(newTicketCreated);
            }
            using (var context = new TicketDbContext(dbOptions))
            {
                var createdTicket = context.Tickets.SingleOrDefault(ticket => ticket.Id == 1);
                Assert.NotNull(createdTicket);
                Assert.Equal("Test for creating tickets", createdTicket.Subject);
            }
            var ticketId = _ticketRepository.CreateTicket(newTicketCreated);
            Assert.NotNull(ticketId);

        }
        private DbContextOptions<TicketDbContext> CreateDbContext()
        {
            var dbName = Guid.NewGuid().ToString();
            var options = new DbContextOptionsBuilder<TicketDbContext>()
                .UseSqlServer($"Server=localhost;Database={dbName};Trusted_Connection=True;")
                .Options;
            AddDummyDataToDb(options);
            return options;

        }
        private void AddDummyDataToDb(DbContextOptions<TicketDbContext> options)
        {
            using (var context = new TicketDbContext(options))
            {
                // Seed the test database with any required data
                context.TicketsType.AddRange(new List<TicketType>
                {
                new TicketType { Id = 1, Name = "DummyType1" },
                new TicketType { Id = 2, Name = "DummyType2" }
                });
                context.Status.AddRange(new List<TicketStatus>
                {
                new TicketStatus { Id = 1, Name = "DummyStatus1" },
                new TicketStatus { Id = 2, Name = "DummyStatus2" }
                });
                context.TicketServicesType.AddRange(new List<TicketServiceType>
                {
                new TicketServiceType { Id = 1, Name = "TicketService1" },
                new TicketServiceType { Id = 2, Name = "TicketService2" }
                });
                context.Users.Add(new User { Id = new Guid("76d2409e-3ddf-493a-b4d4-c65e8e0fa8c0"), Name = "Dummy userName" });
                context.SaveChanges();
            }
        }
    }
}
