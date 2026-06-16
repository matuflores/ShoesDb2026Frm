using ShoesDb2026.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoesDb2026.Data.Interfaces
{
    public interface IShoesRepository:IRepositorioGenerico<Shoe>
    {
        
        bool ExistSameName(string model, int brandId,int sizeId, int? shoeId = null);

        List<Shoe> GetByBrand(int brandId);

        List<Shoe> GetBySport(int sportId);

        List<Shoe> GetBySize(int sizeId);

        List<Shoe> OrderByModel();

        List<Shoe> OrderByPrice();

        List<Shoe> OrderByBrand();
    }
}
