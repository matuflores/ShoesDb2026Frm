using ShoesDb2026.Entities;
using ShoesDb2026.Service.DTOs.Brand;
using ShoesDb2026.Service.DTOs.Size;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoesDb2026.Service.Mappers
{
    public static class SizeMapper
    {
        public static Size ToEntity(SizeCreateDto dto)
        {
            return new Size
            {
                SizeNumber = dto.SizeNumber,
                Active=true
            };
        }
        public static SizeListDto ToListDto(Size size)
        {
            return new SizeListDto
            {
                SizeId = size.SizeId,
                SizeNumber = size.SizeNumber,
                Active=size.Active
            };
        }
        public static SizeUpdateDto ToUpdateDto(Size size)
        {
            return new SizeUpdateDto
            {
                SizeId = size.SizeId,
                SizeNumber = size.SizeNumber,
                Active = size.Active,
                RowVersion = size.RowVersion
            };
        }

        public static SizeDeleteDto ToDeleteDto(Size size)
        {
            return new SizeDeleteDto
            {
                SizeId = size.SizeId,
                RowVersion = size.RowVersion
            };
        }
    }
}
