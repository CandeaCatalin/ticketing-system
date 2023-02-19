using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketingSystem.Exceptions;
using TicketingSystem.Identity.Application.Abstractions;
using TicketingSystem.Identity.Domain.Models.API;

namespace TicketingSystem.Identity.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class IdentityController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public IdentityController(IUserRepository userRepository) {
            _userRepository = userRepository;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            try
            {
                var token =await _userRepository.Login(model);
                return Ok(token);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }catch(Exception e)
            {
                return BadRequest(e);
            }

        }
      
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            try
            {
                await _userRepository.Register(model);
                return Ok();
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { Exception = ex.Message });
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
            
        }
    }
}
