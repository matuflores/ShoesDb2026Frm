using ShoesDb2026.Entities;
using ShoesDb2026.Service.DTOs.Genre;
using ShoesDb2026.Service.DTOs.Sport;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoesDb2026.Service.Mappers
{
    public static class GenreMapper
    {
        public static Genre ToEntity(GenreCreateDto dto)
        {
            return new Genre
            {
                GenreName = dto.GenreName
            };
        }

        public static GenreListDto ToListDto(Genre genre)
        {
            return new GenreListDto
            {
                GenreId = genre.GenreId,
                GenreName = genre.GenreName
            };
        }

        public static GenreUpdateDto ToUpdateDto(Genre genre)
        {
            return new GenreUpdateDto
            {
                GenreId = genre.GenreId,
                GenreName = genre.GenreName,
                RowVersion = genre.RowVersion

            };
        }
    }
}
