using Microsoft.EntityFrameworkCore;
using ShoesDb2026.Data.Interfaces;
using ShoesDb2026.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoesDb2026.Data.Repositories
{
    public class GenreRepository :RepositorioGenerico<Genre>, IGenresRepository
    {
        public GenreRepository(ShoesDb2026DbContext context) : base(context)
        {
        }

        public bool ExistSameName(string genreName, int? genreId = null)
        {
            return _context.Genres.Any(g => g.GenreName == genreName && g.GenreId != genreId);
        }
        public bool HasShoes(int genreId)
        {
            return _context.Shoes.Any(s => s.GenreId == genreId);
        }
    }
}
