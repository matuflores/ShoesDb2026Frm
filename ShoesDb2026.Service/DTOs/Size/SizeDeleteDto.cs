using System;
using System.Collections.Generic;
using System.Text;

namespace ShoesDb2026.Service.DTOs.Size
{
    public class SizeDeleteDto
    {
        public int SizeId { get; set; }
        public byte[] RowVersion { get; set; } = null!;
    }
}
