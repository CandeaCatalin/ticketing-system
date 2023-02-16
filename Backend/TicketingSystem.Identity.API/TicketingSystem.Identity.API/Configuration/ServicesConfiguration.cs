using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.CompilerServices;
using System.Text;

namespace TicketingSystem.Identity.API.Configuration
{
    public static class ServicesConfiguration
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
