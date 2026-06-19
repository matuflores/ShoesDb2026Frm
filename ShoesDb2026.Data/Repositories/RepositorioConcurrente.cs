using ShoesDb2026.Data.Interfaces;
using ShoesDb2026.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoesDb2026.Data.Repositories
{
    public class RepositorioConcurrente<T> : RepositorioGenerico<T>,
        IRepositorioConcurrente<T> where T : class, IConcurrencyEntity
    {
        public RepositorioConcurrente(ShoesDb2026DbContext context) : base(context)
        {
        }
        public override void Delete(int id)
        {
            throw new NotImplementedException("Debe usar la version de concurrencia");
        }

        public void Delete(int id, byte[] rowVersion)
        {
            var entityInDb = _dbSet.Find(id);
            if (entityInDb is null)
            {
                throw new KeyNotFoundException($"No se pudo borrar la entidad con ID: {id} de la tabla {typeof(T).Name}");
            }
            var entity = _context.Entry(entityInDb);
            entity.OriginalValues["RowVersion"] = rowVersion;
            _dbSet.Remove(entityInDb);
        }

        public void Update(T entity, int id, byte[] rowVersion)
        {
            var entityInDb = _dbSet.Find(id);
            if (entityInDb is null)
            {
                throw new KeyNotFoundException($"No se pudo editar la entidad con ID: {id} de la tabla {typeof(T).Name}");
            }
            var entityE = _context.Entry(entityInDb);
            entityE.OriginalValues["RowVersion"] = rowVersion;
            _dbSet.Entry(entityInDb).CurrentValues.SetValues(entity);//aca no uso dbcontex y uso dbset, porque el dbset ya tiene el contexto asociado, entonces no necesito usar el contexto para actualizar la entidad, solo necesito usar el dbset para encontrar la entidad y luego actualizarla con los valores de la entidad que me pasan por parametro
        }    
    }
}
