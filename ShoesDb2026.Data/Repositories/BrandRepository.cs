using Microsoft.EntityFrameworkCore;
using ShoesDb2026.Data.Interfaces;
using ShoesDb2026.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoesDb2026.Data.Repositories
{
    public class BrandRepository : RepositorioConcurrente<Brand>, IBrandsRepository
    {
        public BrandRepository(ShoesDb2026DbContext context) : base(context)
        {
            
        }

        public bool ExistSameName(string brandName, int? brandId = null)
        {
            return _context.Brands.Any(b => b.BrandName == brandName && b.BrandId != brandId);
        }
        
        public bool HasShoes(int brandId)
        {
            return _context.Shoes.Any(s => s.BrandId == brandId);
        }

        
    }
}
