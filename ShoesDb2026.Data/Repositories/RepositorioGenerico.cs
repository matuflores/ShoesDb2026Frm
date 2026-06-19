using Microsoft.EntityFrameworkCore;
using ShoesDb2026.Data.Interfaces;
using ShoesDb2026.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoesDb2026.Data.Repositories
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : class
    {
        protected readonly ShoesDb2026DbContext _context;
        protected readonly DbSet<T> _dbSet;
        public RepositorioGenerico(ShoesDb2026DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
            //try
            //{
            //    _dbSet.Add(entity);
            //}
            //catch (Exception ex)
            //{

            //    throw new Exception($"Error al intentar agregar un registro en la tabla de {typeof(T).Name}",ex);
            //}
        }

        public virtual void Delete(int id)
        {
            
            var entity = _dbSet.Find(id);
            if (entity is null)
            {
                throw new KeyNotFoundException($"No se pudo borrar la entidad con ID: {id} de la tabla {typeof(T).Name}");
            }
            _dbSet.Remove(entity);
            
        }

        public List<T> GetAll()
        {
            
            return _dbSet.AsNoTracking().ToList();
            
        }

        public T? GetById(int id)
        {
            
            return _dbSet.Find(id);
        }

        public IQueryable<T> Query()
        {
            return _dbSet.AsNoTracking();
        }

        public void Update(T entity, int id)
        {
            
            var entityInDb = _dbSet.Find(id);
            if (entityInDb is null)
            {
                throw new KeyNotFoundException($"No se pudo editar la entidad con ID: {id} de la tabla {typeof(T).Name}");
            }
            _dbSet.Entry(entityInDb).CurrentValues.SetValues(entity);//aca no uso dbcontex y uso dbset, porque el dbset ya tiene el contexto asociado, entonces no necesito usar el contexto para actualizar la entidad, solo necesito usar el dbset para encontrar la entidad y luego actualizarla con los valores de la entidad que me pasan por parametro
        }
    }
}
