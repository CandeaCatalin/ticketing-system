using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSystem.Tickets.Application.Services
{
    public static class JwtService
    {
        public static Guid getUserIdFromJwt(string jwtToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(jwtToken);
            var token = jsonToken as JwtSecurityToken;
            var userId = token.Claims.First(claim => claim.Type == "sub").Value;
            return new Guid(userId);
        }
    }
}
