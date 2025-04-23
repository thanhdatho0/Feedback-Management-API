using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.ImageDtos;
using Domain.Entities;

namespace DataAccess.EFCore.Mappers
{
    public static class ImageMappers
    {
        public static Image ToImageFromCreateDto(this ImageCreateDto imageCreateDto)
        {
            return new Image
            {
                Url = imageCreateDto.Url,
                Alt = imageCreateDto.Alt,
                TicketId = imageCreateDto.TicketId,
            };
        }
    }
}
