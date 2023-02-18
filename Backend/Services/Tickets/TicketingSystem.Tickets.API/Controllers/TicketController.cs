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

        public TicketController(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateTicketAsync(CreateTicketModel model)
        {
            try
            {
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
    }
}
