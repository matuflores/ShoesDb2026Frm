using ShoesDb2026.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoesDb2026.Data.Interfaces
{
    public interface IRepositorioConcurrente<T>:IRepositorioGenerico<T> where T: class,IConcurrencyEntity
    {
        void Update(T entity, int id, byte[] rowVersion);
        void Delete(int id, byte[] rowVersion);
    }
}
