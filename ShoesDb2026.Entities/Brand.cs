using ShoesDb2026.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ShoesDb2026.Entities
{
    public class Brand:IConcurrencyEntity
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public bool Active { get; set; } 

        //public ICollection<Shoe> Shoes { get; set; } = new List<Shoe>();

        public byte[] RowVersion { get; set; } = null!;
    }
}
