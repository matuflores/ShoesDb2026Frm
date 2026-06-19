using ShoesDb2026.Service.Common;
using ShoesDb2026.Service.DTOs.Brand;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoesDb2026.Service.Interfaces
{
    public interface IBrandService
    {
        Result<List<BrandListDto>> GetAll();
        Result<BrandUpdateDto> GetForUpdate(int id);
        Result<BrandDeleteDto> GetForDelete(int id);

        Result Add(BrandCreateDto brandDto);
        Result Update(BrandUpdateDto brandDto);
        Result Delete(BrandDeleteDto brandDto);
        Result<List<BrandListDto>> FilterForActive(bool active);
    }
}
