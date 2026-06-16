using FluentValidation;
using ShoesDb2026.Data;
using ShoesDb2026.Entities;
using ShoesDb2026.Service.Common;
using ShoesDb2026.Service.DTOs.Genre;
using ShoesDb2026.Service.DTOs.Sport;
using ShoesDb2026.Service.Interfaces;
using ShoesDb2026.Service.Mappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoesDb2026.Service.Services
{
    public class GenreService:IGenreService
    {
        private readonly IValidator<Genre> _validator;
        private readonly IUnitOfWork _uow;
        public GenreService(IValidator<Genre> validator, IUnitOfWork uow)
        {
            _validator = validator;
            _uow = uow;
        }
        public Result Add(GenreCreateDto genreDto)
        {
            var genre = GenreMapper.ToEntity(genreDto);
            var result = _validator.Validate(genre);
            if (!result.IsValid)
            {
                return Result.Failure(result.Errors.Select(e => e.ErrorMessage).ToList());
            }

            if (_uow.Genres.ExistSameName(genre.GenreName))
            {
                return Result.Failure("GENRE ALREADY EXISTS");
            }
            try
            {
                _uow.Genres.Add(genre);
                _uow.Save();
                return Result.Success();

            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        public Result Delete(int id)
        {
            var genre = _uow.Genres.GetById(id);
            if (genre == null)
            {
                return Result.Failure("GENRE NOT FOUND");
            }
            if (_uow.Genres.HasShoes(id))
            {
                return Result.Failure("GENRE HAS SHOES, CAN'T BE DELETED");
            }
            try
            {
                _uow.Genres.Delete(id);
                _uow.Save();
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        public Result<List<GenreListDto>> GetAll()
        {
            var genres = _uow.Genres.GetAll().Select(GenreMapper.ToListDto).ToList();
            return Result<List<GenreListDto>>.Success(genres);
        }

        public Result<GenreUpdateDto> GetForUpdate(int id)
        {
            var genre = _uow.Genres.GetById(id);
            if (genre == null)
            {
                return Result<GenreUpdateDto>.Failure("GENRE NOT FOUND");
            }

            return Result<GenreUpdateDto>.Success(GenreMapper.ToUpdateDto(genre));
        }

        public Result Update(GenreUpdateDto genreDto)
        {
            var genre = _uow.Genres.GetById(genreDto.GenreId);
            if (genre == null)
            {
                return Result.Failure("GENRE NOT FOUND");
            }
            genre.GenreName = genreDto.GenreName;
            genre.RowVersion = genreDto.RowVersion;

            if (_uow.Genres.ExistSameName(genre.GenreName, genre.GenreId))
            {
                return Result.Failure("GENRE ALREADY EXISTS");
            }
            try
            {
                _uow.Genres.Update(genre);
                _uow.Save();
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }
    }
}
