using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TicketingSystem.Common.API;
using TicketingSystem.Tickets.API.Configuration;
using TicketingSystem.Tickets.DataAccess.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTicketingSystemSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("ticket");
if (connectionString is not null)
{
    builder.Services.AddServices(connectionString);
}
var jwtSecretKey = builder.Configuration["jwtOptions:Secret"];
builder.Services.AddTicketingSystemAuth(jwtSecretKey);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<TicketDbContext>();
    context.Database.Migrate();
}
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
