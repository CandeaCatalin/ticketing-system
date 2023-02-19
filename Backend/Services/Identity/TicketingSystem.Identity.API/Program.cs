using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TicketingSystem.Common.API;
using TicketingSystem.Identity.API.Configuration;
using TicketingSystem.Identity.DataAccess.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTicketingSystemSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("identity");
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

    var context = services.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
app.UseSwagger();
app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
