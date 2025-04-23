using DataAccess.EFCore.Mappers;
using Domain.DTOs.RequestTicketDtos;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestTicketController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                if(!ModelState.IsValid) return BadRequest(ModelState);
                var reqTickets = await _unitOfWork.RequestTickets.GetAll();
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
                var reqTickets = await _unitOfWork.RequestTickets.GetById(id);
                if (reqTickets == null) return StatusCode(400, "Không tìm thấy ticket");
                return Ok(reqTickets.ToRequestTicketDetailDto());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(RequestTicketCreateDto reqTicketCreateDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var reqTicket = reqTicketCreateDto.ToRequestTicketFromCreateDto();
                try
                {
                    _unitOfWork.RequestTickets.Add(reqTicket);
                }
                catch(Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
                await _unitOfWork.Complete();
                return Ok(reqTicketCreateDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("receive-ticket")]
        public async Task<IActionResult> UpdateToReceived([FromQuery] Guid ticketId)
        {
            try
            {
                if (!ModelState.IsValid) 
                    return BadRequest(ModelState);
                var reqTicket = await _unitOfWork.RequestTickets.GetById(ticketId);
                if (reqTicket == null) 
                    return StatusCode(400, "Không tìm thấy ticket");
                else
                    reqTicket.UpdateToReceived();
                await _unitOfWork.Complete();
                return Ok(reqTicket.ToRequestTicketDto());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("resolved-ticket")]
        public async Task<IActionResult> UpdateToResolved([FromQuery] Guid ticketId)
        {
            try
            {
                if (!ModelState.IsValid) 
                    return BadRequest(ModelState);
                var reqTicket = await _unitOfWork.RequestTickets.GetById(ticketId);
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
