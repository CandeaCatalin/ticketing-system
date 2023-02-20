using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TicketingSystem.Exceptions;
using TicketingSystem.Tickets.Application.Abstractions;
using TicketingSystem.Tickets.Application.Services;
using TicketingSystem.Tickets.Domain.Models;
using TicketingSystem.Tickets.Domain.Models.API;

namespace TicketingSystem.Tickets.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
                var jwtToken = await HttpContext.GetTokenAsync("access_token");
                Guid userId = JwtService.getUserIdFromJwt(jwtToken);
                await _userRepository.AddUserInDb(userId, model.UserName);
                model.UserId = userId;
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
        [HttpPost("close")]
        public async Task<IActionResult> CloseTicketAsync(CloseTicketModel model)
        {
            try
            {
                await _ticketRepository.CloseTicket(model);
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetTicketsForUserAsync()
        {
            try
            {
                var jwtToken = await HttpContext.GetTokenAsync("access_token");
                Guid userId = JwtService.getUserIdFromJwt(jwtToken);
                List<Ticket> ticketsForUser =await _ticketRepository.GetTicketsForUser(userId);
                return Ok(ticketsForUser);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [HttpGet("getStandardProperties")]
        public async Task<IActionResult> GetTicketStandardPropertiesAsync()
        {
            try
            {
                var propertiesCollection = await _ticketRepository.GetStandardProperties();
                return Ok(propertiesCollection);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }

    }
}
