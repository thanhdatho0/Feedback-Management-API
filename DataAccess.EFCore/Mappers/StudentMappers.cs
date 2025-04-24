using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.StudentDtos;
using Domain.Entities;

namespace DataAccess.EFCore.Mappers
{
    public static class StudentMappers
    {
        public static StudentDetailDto ToStudentDetailDto (this Student student)
        {
            return new StudentDetailDto
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                RequestTickets = student.Tickets.Select(r => r.ToRequestTicketDto()).ToList(),
            };
        }
    }
}
