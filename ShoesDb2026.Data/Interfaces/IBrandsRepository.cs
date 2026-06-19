using ShoesDb2026.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoesDb2026.Data.Interfaces
{
    public interface IBrandsRepository : IRepositorioConcurrente<Brand>
    {
        bool ExistSameName(string brandName, int? brandId = null);
        bool HasShoes(int brandId);
    }
}
