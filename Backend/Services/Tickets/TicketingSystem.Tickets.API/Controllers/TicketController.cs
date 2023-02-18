using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketingSystem.Exceptions;
using TicketingSystem.Tickets.Application.Abstractions;
using TicketingSystem.Tickets.Domain.Models.API;

namespace TicketingSystem.Tickets.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IUserRepository _userRepository;

        public TicketController(ITicketRepository ticketRepository, IUserRepository userRepository)
        {
            _ticketRepository = ticketRepository;
            _userRepository = userRepository;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateTicketAsync(CreateTicketModel model)
        {
            try
            {
                await _userRepository.AddUserInDb(model.UserId, model.UserName);
                await _ticketRepository.CreateTicket(model);
                return Ok();
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteTicketAsync(DeleteTicketModel model)
        {
            try
            {
                await _ticketRepository.DeleteTicket(model);
                return Ok();
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateTicketAsync(UpdateTicketModel model)
        {
            try
            {
                await _ticketRepository.UpdateTicket(model);
                return Ok();
            }catch(ValidationException e)
            {
                return BadRequest(e.Message);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        
    }
}
