using Domain.DTOs.TicketUrgencyDtos;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketUrgencyController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        [HttpPost]
        public async Task<IActionResult> Create(TicketUrgencyCreateDto ticketUrgencyCreateDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var ticketUrgency = new TicketUrgency
                {
                    Urgency = ticketUrgencyCreateDto.Urgency
                };
                try
                {
                    _unitOfWork.TicketUrgencies.Add(ticketUrgency);
                }
                catch
                {
                    return StatusCode(500, "Không thể thêm");
                }
                await _unitOfWork.Complete();
                return Ok(ticketUrgencyCreateDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                return Ok(await _unitOfWork.TicketUrgencies.GetAll());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
