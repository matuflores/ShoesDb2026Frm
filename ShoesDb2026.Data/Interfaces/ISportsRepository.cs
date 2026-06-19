using ShoesDb2026.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoesDb2026.Data.Interfaces
{
    public interface ISportsRepository:IRepositorioConcurrente<Sport>
    {
        bool ExistSameName(string sportName, int? sportId = null);

        bool HasShoes(int sportId);
    }
}
