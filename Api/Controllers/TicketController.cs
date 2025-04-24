using DataAccess.EFCore.Mappers;
using Domain.DTOs.TicketDtos;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                if(!ModelState.IsValid) return BadRequest(ModelState);
                var reqTickets = await _unitOfWork.Tickets.GetAll();
                return Ok(reqTickets.Select(r => r.ToRequestTicketDto()));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            } 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var reqTickets = await _unitOfWork.Tickets.GetById(id);
                if (reqTickets == null) return StatusCode(400, "Không tìm thấy ticket");
                return Ok(reqTickets.ToRequestTicketDetailDto());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(TicketCreateDto ticketCreateDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var reqTicket = ticketCreateDto.ToRequestTicketFromCreateDto();
                try
                {
                    _unitOfWork.Tickets.Add(reqTicket);
                }
                catch(Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
                await _unitOfWork.Complete();
                return Ok(ticketCreateDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize(Roles = "Employee")]
        [HttpPut("receive-ticket")]
        public async Task<IActionResult> UpdateToReceived([FromQuery] Guid ticketId, string EmployeeId)
        {
            try
            {
                if (!ModelState.IsValid) 
                    return BadRequest(ModelState);
                var ticket = await _unitOfWork.Tickets.GetById(ticketId);
                var employee = await _unitOfWork.Employees.Find(e => e.Id == EmployeeId);
                if (ticket == null || employee == null) 
                    return StatusCode(400, "Không tìm thấy ticket");
                else
                    ticket.UpdateToReceived(EmployeeId);
                await _unitOfWork.Complete();
                return Ok(ticket.ToRequestTicketDto());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize(Roles = "Employee")]
        [HttpPut("resolved-ticket")]
        public async Task<IActionResult> UpdateToResolved([FromQuery] Guid ticketId)
        {
            try
            {
                if (!ModelState.IsValid) 
                    return BadRequest(ModelState);
                var reqTicket = await _unitOfWork.Tickets.GetById(ticketId);
                if (reqTicket == null) 
                    return StatusCode(400, "Không tìm thấy ticket");
                else
                    reqTicket.UpdateToResolved();
                await _unitOfWork.Complete();
                return Ok(reqTicket.ToRequestTicketDto());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
