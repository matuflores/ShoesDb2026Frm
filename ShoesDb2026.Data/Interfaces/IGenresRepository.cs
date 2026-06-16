using ShoesDb2026.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoesDb2026.Data.Interfaces
{
    public interface IGenresRepository : IRepositorioGenerico<Genre>
    {
        bool ExistSameName(string genreName, int? genreId = null);
        bool HasShoes(int genreId);
    }
}
