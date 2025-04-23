using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.RequestTicketDtos;

namespace Domain.DTOs.StudentDtos
{
    public class StudentDetailDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public ICollection<RequestTicketDto> RequestTickets { get; set; } = [];
    }
}
