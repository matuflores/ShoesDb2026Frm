using System;
using System.Collections.Generic;
using System.Text;

namespace ShoesDb2026.Service.DTOs.Genre
{
    public class GenreUpdateDto
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; } = null!;
        public byte[] RowVersion { get; set; } = null!;
    }
}
