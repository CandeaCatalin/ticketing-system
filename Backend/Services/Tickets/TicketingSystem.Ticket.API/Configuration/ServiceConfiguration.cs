using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace TicketingSystem.Ticket.API.Configuration
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScopes();
            services.AddHttpContextAccessor();
            return services;
        }
        private static IServiceCollection AddScopes(this IServiceCollection services)
        {
            return services;
        }
    }
}
