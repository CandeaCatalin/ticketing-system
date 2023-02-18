using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TicketingSystem.Tickets.DataAccess.Database;

namespace TicketingSystem.Tickets.API.Configuration
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services, string connectionString)
        {
            services.AddDataServices(connectionString);
            services.AddScopes();
            services.AddHttpContextAccessor();
            return services;
        }
        private static IServiceCollection AddScopes(this IServiceCollection services)
        {
            return services;
        }
        private static IServiceCollection AddDataServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<TicketDbContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("TicketingSystem.Tickets.DataAccess")));
            
            return services;
        }
    }
}
