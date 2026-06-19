using ShoesDb2026.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoesDb2026.Data.Interfaces
{
    public interface ISizesRepository:IRepositorioConcurrente<Size>
    {
        bool ExistSameName(decimal sizeNumber, int? sizeId = null);

        bool HasShoes(int sizeId);
    }
}
