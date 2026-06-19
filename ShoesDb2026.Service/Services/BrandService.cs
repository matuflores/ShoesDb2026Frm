using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ShoesDb2026.Data;
using ShoesDb2026.Entities;
using ShoesDb2026.Service.Common;
using ShoesDb2026.Service.DTOs.Brand;
using ShoesDb2026.Service.DTOs.Sport;
using ShoesDb2026.Service.Interfaces;
using ShoesDb2026.Service.Mappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoesDb2026.Service.Services
{
    public class BrandService : IBrandService
    {
        private readonly IValidator<Brand> _validator;
        private readonly IUnitOfWork _uow;

        public BrandService(IValidator<Brand> validator, IUnitOfWork unitOfWork)
        {
            _validator = validator;
            _uow = unitOfWork;
        }
        public Result Add(BrandCreateDto brandDto)
        {
            var brand = BrandMapper.ToEntity(brandDto);
            var result = _validator.Validate(brand);
            if (!result.IsValid)
            {
                return Result.Failure(result.Errors.Select(e => e.ErrorMessage).ToList());
            }
            if (_uow.Brands.ExistSameName(brand.BrandName))
            {
                return Result.Failure("BRAND ALREADY EXISTS");
            }
            try
            {
                _uow.Brands.Add(brand);
                _uow.Save();
                return Result.Success();

            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        public Result Delete(BrandDeleteDto brandDto)
        {
            try
            {
                _uow.Brands.Delete(brandDto.BrandId,
                    brandDto.RowVersion);
                _uow.Save();
                return Result.Success();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _uow.RollBack();
                return Result.ConcurrencyFailure("Otro usuario ha modificado la marca.");
            }
            catch (KeyNotFoundException ex)
            {
                _uow.RollBack();
                return Result.Failure($"Marca con ID: {brandDto.BrandId} no encontrada.");
            }
            catch (Exception ex)
            {
                _uow.RollBack();
                return Result.Failure($"Error al intentar eliminar la marca: {ex.Message}");
            }
        }

        public Result<List<BrandListDto>> FilterForActive(bool active)
        {
            try
            {
                var query = _uow.Brands.Query();
                var list = query.Where(b => b.Active == active);
                var listDto = list.Select(BrandMapper.ToListDto).ToList();
                return Result<List<BrandListDto>>.Success(listDto);
            }
            catch (Exception ex)
            {

                return Result<List<BrandListDto>>.Failure($"Error al intentar filtrar los tipos de Marcas: {ex.Message}");
            }
        }

        public Result<List<BrandListDto>> GetAll()
        {
            var brands = _uow.Brands.GetAll().Select(BrandMapper.ToListDto).ToList();
            return Result<List<BrandListDto>>.Success(brands);
        }

        public Result<BrandDeleteDto> GetForDelete(int id)
        {
            var brand = _uow.Brands.GetById(id);
            if (brand == null)
            {
                return Result<BrandDeleteDto>.Failure("BRAND NOT FOUND");
            }

            return Result<BrandDeleteDto>.Success(BrandMapper.ToDeleteDto(brand));
        }

        public Result<BrandUpdateDto> GetForUpdate(int id)
        {
            var brand = _uow.Brands.GetById(id);
            if (brand == null) 
            {
                return Result<BrandUpdateDto>.Failure("BRAND NOT FOUND");
            }

            return Result<BrandUpdateDto>.Success(BrandMapper.ToUpdateDto(brand));
        }

        public Result Update(BrandUpdateDto brandDto)
        {
            var brand=_uow.Brands.GetById(brandDto.BrandId);
            if (brand==null)
            {
                return Result.Failure("BRAND NOT FOUND");
            }
            brand.BrandName = brandDto.BrandName;
            brand.ImageUrl = brandDto.ImageUrl;
            brand.Active = brandDto.Active;
            brand.RowVersion = brandDto.RowVersion;

            if (_uow.Brands.ExistSameName(brand.BrandName, brand.BrandId))
            {
                return Result.Failure("BRAND ALREADY EXISTS");
            }
            try
            {
                _uow.Brands.Update(brand, brand.BrandId);
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
