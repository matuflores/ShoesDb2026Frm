using ShoesDb2026.Service.Common;
using ShoesDb2026.Service.DTOs.Genre;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoesDb2026.Service.Interfaces
{
    public interface IGenreService
    {
        Result<List<GenreListDto>> GetAll();
        Result<GenreUpdateDto> GetForUpdate(int id);

        Result Add(GenreCreateDto genreDto);
        Result Update(GenreUpdateDto genreDto);
        Result Delete(int id);
    }
}
