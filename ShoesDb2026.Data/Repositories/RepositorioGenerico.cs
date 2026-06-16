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
            try
            {
                _dbSet.Add(entity);
            }
            catch (Exception ex)
            {

                throw new Exception($"Error al intentar agregar un registro en la tabla de {typeof(T).Name}",ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var entity = _dbSet.Find(id);
                if (entity is null)
                {
                    throw new KeyNotFoundException($"No se pudo borrar la entidad con ID: {id} de la tabla {typeof(T).Name}");
                }
                _dbSet.Remove(entity);
            }
            catch (Exception ex)
            {

                throw new Exception($"Error al intentar borrar un registro en la tabla de {typeof(T).Name}", ex);
            }
        }

        public List<T> GetAll()
        {
            try
            {
                return _dbSet.AsNoTracking().ToList();
            }
            catch (Exception ex)
            {

                throw new Exception($"Error al intentar recuperar los registros en la tabla de {typeof(T).Name}", ex);
            }
        }

        public T? GetById(int id)
        {
            try
            {
                return _dbSet.Find(id);
            }
            catch (Exception ex)
            {

                throw new Exception($"Error al intentar buscar un registro en la tabla de {typeof(T).Name}", ex);
            }
        }

        public IQueryable<T> Query()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public void Update(T entity, int id)
        {
            try
            {
                var entityInDb = _dbSet.Find(id);
                if (entityInDb is null)return;
                _dbSet.Entry(entityInDb).CurrentValues.SetValues(entity);//aca no uso dbcontex y uso dbset, porque el dbset ya tiene el contexto asociado, entonces no necesito usar el contexto para actualizar la entidad, solo necesito usar el dbset para encontrar la entidad y luego actualizarla con los valores de la entidad que me pasan por parametro
            }
            catch (Exception ex)
            {

                throw new Exception($"Error al intentar actualizar un registro en la tabla de {typeof(T).Name}", ex);
            }
        }
    }
}
