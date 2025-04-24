using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.StudentDtos;

namespace Domain.DTOs.TicketDtos
{
    public class TicketDetailDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string CategoryItem { get; set; } = string.Empty;
        public StudentDto SenderInfo { get; set; } = new StudentDto();
    }
}
