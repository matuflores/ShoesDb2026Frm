using Microsoft.EntityFrameworkCore;
using ShoesDb2026.Data.Interfaces;
using ShoesDb2026.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoesDb2026.Data.Repositories
{
    public class SportRepository :RepositorioGenerico<Sport>, ISportsRepository
    {
        public SportRepository(ShoesDb2026DbContext context) : base(context)
        {
        }

        public bool ExistSameName(string sportName, int? sportId = null)
        {
            return _context.Sports.Any(s => s.SportName == sportName && s.SportId != sportId);
        }
        public bool HasShoes(int sportId)
        {
            return _context.Shoes.Any(s => s.SportId == sportId);
        }

    }
}
