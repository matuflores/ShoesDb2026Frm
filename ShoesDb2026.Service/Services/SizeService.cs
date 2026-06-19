using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ShoesDb2026.Data;
using ShoesDb2026.Entities;
using ShoesDb2026.Service.Common;
using ShoesDb2026.Service.DTOs.Size;
using ShoesDb2026.Service.DTOs.Sport;
using ShoesDb2026.Service.Interfaces;
using ShoesDb2026.Service.Mappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoesDb2026.Service.Services
{
    public class SizeService : ISizeService
    {
        private readonly IValidator<Size> _validator;
        private readonly IUnitOfWork _uow;

        public SizeService(IValidator<Size> validator, IUnitOfWork uow)
        {
            _validator = validator;
            _uow = uow;
        }
        public Result Add(SizeCreateDto sizeDto)
        {
            var size = SizeMapper.ToEntity(sizeDto);
            var result = _validator.Validate(size);
            if (!result.IsValid)
            {
                return Result.Failure(result.Errors.Select(e => e.ErrorMessage).ToList());
            }

            if (_uow.Sizes.ExistSameName(size.SizeNumber))
            {
                return Result.Failure("SIZE ALREADY EXISTS");
            }
            try
            {
                _uow.Sizes.Add(size);
                _uow.Save();
                return Result.Success();

            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        

        public Result Delete(SizeDeleteDto sizeDto)
        {
            try
            {
                _uow.Sizes.Delete(sizeDto.SizeId,
                    sizeDto.RowVersion);
                _uow.Save();
                return Result.Success();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _uow.RollBack();
                return Result.ConcurrencyFailure("Otro usuario ha modificado el talle.");
            }
            catch (KeyNotFoundException ex)
            {
                _uow.RollBack();
                return Result.Failure($"Talla con ID: {sizeDto.SizeId} no encontrada.");
            }
            catch (Exception ex)
            {
                _uow.RollBack();
                return Result.Failure($"Error al intentar eliminar la talla: {ex.Message}");
            }
        }

        public Result<List<SizeListDto>> FilterForActive(bool active)
        {
            try
            {
                var query = _uow.Sizes.Query();
                var list = query.Where(s => s.Active == active);
                var listDto = list.Select(SizeMapper.ToListDto).ToList();
                return Result<List<SizeListDto>>.Success(listDto);
            }
            catch (Exception ex)
            {

                return Result<List<SizeListDto>>.Failure($"Error al intentar filtrar las tallas: {ex.Message}");
            }
        }

        public Result<List<SizeListDto>> GetAll()
        {
            var sizes = _uow.Sizes.GetAll()
                .Select(SizeMapper.ToListDto)
                .ToList();
            return Result<List<SizeListDto>>.Success(sizes);
        }

        public Result<SizeDeleteDto> GetForDelete(int id)
        {
            var size = _uow.Sizes.GetById(id);
            if (size == null)
            {
                return Result<SizeDeleteDto>.Failure("SIZE NOT FOUND");
            }

            return Result<SizeDeleteDto>.Success(SizeMapper.ToDeleteDto(size));
        }

        public Result<SizeUpdateDto> GetForUpdate(int id)
        {
            var size = _uow.Sizes.GetById(id);
            if (size == null)
            {
                return Result<SizeUpdateDto>.Failure("SIZE NOT FOUND");
            }

            return Result<SizeUpdateDto>.Success(SizeMapper.ToUpdateDto(size));
        }

        public Result Update(SizeUpdateDto sizeDto)
        {
            var size = _uow.Sizes.GetById(sizeDto.SizeId);
            if (size == null)
            {
                return Result.Failure("SIZE NOT FOUND");
            }
            size.SizeNumber = sizeDto.SizeNumber;
            size.RowVersion=sizeDto.RowVersion;

            if (_uow.Sizes.ExistSameName(size.SizeNumber, size.SizeId))
            {
                return Result.Failure("SIZE ALREADY EXISTS");
            }
            try
            {
                _uow.Sizes.Update(size, size.SizeId);
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
