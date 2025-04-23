using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.RequestTicketDtos;
using Domain.DTOs.StudentDtos;
using Domain.Entities;

namespace DataAccess.EFCore.Mappers
{
    public static class RequestTicketMappers
    {

        public static RequestTicketDto ToRequestTicketDto(this RequestTicket requestTicket)
        {
            return new RequestTicketDto
            {
                Id = requestTicket.Id,
                Title = requestTicket.Title,
                Body = requestTicket.Body,
                Status = requestTicket.Status,
                Category = requestTicket.CategoryItem!.Category!.Name,
                CategoryItem = requestTicket.CategoryItem!.Name
            };
        }

        public static RequestTicketDetailDto ToRequestTicketDetailDto(this RequestTicket requestTicket)
        {
            return new RequestTicketDetailDto
            {
                Id = requestTicket.Id,
                Title = requestTicket.Title,
                Body = requestTicket.Body,
                Status = requestTicket.Status,
                Category = requestTicket.CategoryItem!.Category!.Name,
                CategoryItem = requestTicket.CategoryItem!.Name,
                SenderInfo = new StudentDto
                {
                    FirstName = requestTicket.Student!.FirstName,
                    LastName = requestTicket.Student.LastName,
                    Email = requestTicket.Student.Email,
                }
            };
        }

        public static RequestTicket ToRequestTicketFromCreateDto(this RequestTicketCreateDto requestTicketCreateDto)
        {
            return new RequestTicket
            {
                Title = requestTicketCreateDto.Title,
                Body = requestTicketCreateDto.Body,
                Status = "Chưa tiếp nhận",
                CategoryItemId = requestTicketCreateDto.CategoryItemId,
                TicketUrgencyId = requestTicketCreateDto.TicketUrgencyId,
                StudentId = requestTicketCreateDto.StudentId,
            };
        }

        public static void UpdateToReceived(this RequestTicket requestTicket)
        {
            requestTicket.Status = "Đã tiếp nhận";
        }

        public static void UpdateToResolved(this RequestTicket requestTicket)
        {
            requestTicket.Status = "Đã xử lý";
        }
    }
}
