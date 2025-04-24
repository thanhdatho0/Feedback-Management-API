using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.TicketDtos;
using Domain.DTOs.StudentDtos;
using Domain.Entities;
using System.Net.Sockets;

namespace DataAccess.EFCore.Mappers
{
    public static class RequestTicketMappers
    {

        public static TicketDto ToRequestTicketDto(this Ticket ticket)
        {
            return new TicketDto
            {
                Id = ticket.Id,
                Title = ticket.Title,
                Body = ticket.Body,
                Status = ticket.Status,
                Category = ticket.CategoryItem!.Category!.Name,
                CategoryItem = ticket.CategoryItem!.Name
            };
        }

        public static TicketDetailDto ToRequestTicketDetailDto(this Ticket ticket)
        {
            return new TicketDetailDto
            {
                Id = ticket.Id,
                Title = ticket.Title,
                Body = ticket.Body,
                Status = ticket.Status,
                Category = ticket.CategoryItem!.Category!.Name,
                CategoryItem = ticket.CategoryItem!.Name,
                SenderInfo = new StudentDto
                {
                    FirstName = ticket.Student!.FirstName,
                    LastName = ticket.Student.LastName,
                    Email = ticket.Student.Email,
                }
            };
        }

        public static Ticket ToRequestTicketFromCreateDto(this TicketCreateDto requestTicketCreateDto)
        {
            return new Ticket
            {
                Title = requestTicketCreateDto.Title,
                Body = requestTicketCreateDto.Body,
                Status = "Chưa tiếp nhận",
                CategoryItemId = requestTicketCreateDto.CategoryItemId,
                TicketUrgencyId = requestTicketCreateDto.TicketUrgencyId,
                StudentId = requestTicketCreateDto.StudentId,
            };
        }

        public static void UpdateToReceived(this Ticket ticket, string EmployeeId)
        {
            ticket.EmployeeId = EmployeeId;
            ticket.Status = "Đã tiếp nhận";
        }

        public static void UpdateToResolved(this Ticket ticket)
        {
            ticket.Status = "Đã xử lý";
        }
    }
}
