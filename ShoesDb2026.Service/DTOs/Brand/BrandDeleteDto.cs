using System;
using System.Collections.Generic;
using System.Text;

namespace ShoesDb2026.Service.DTOs.Brand
{
    public class BrandDeleteDto
    {
        public int BrandId { get; set; }
        public byte[] RowVersion { get; set; } = null!;
    }
}
