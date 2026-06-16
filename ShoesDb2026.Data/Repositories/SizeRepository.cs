using Microsoft.EntityFrameworkCore;
using ShoesDb2026.Data.Interfaces;
using ShoesDb2026.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoesDb2026.Data.Repositories
{
    public class SizeRepository :RepositorioGenerico<Size>, ISizesRepository
    {
        public SizeRepository(ShoesDb2026DbContext context) : base(context)
        {
        }

        public bool ExistSameName(decimal sizeNumber, int? sizeId = null)
        {
            //return _context.Sizes.Any(s => s.SizeNumber == sizeNumber && s.SizeId != sizeId);
            return _context.Sizes.Any(s => s.SizeNumber == sizeNumber && (sizeId ==null || s.SizeId!= sizeId));
        }
        
        public bool HasShoes(int sizeId)
        {
            return _context.Shoes.Any(s => s.SizeId == sizeId);
        }
    }
}
