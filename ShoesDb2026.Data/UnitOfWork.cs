using Microsoft.EntityFrameworkCore;
using ShoesDb2026.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoesDb2026.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShoesDb2026DbContext _context;
        public UnitOfWork(ShoesDb2026DbContext context, 
            IBrandsRepository brands, 
            IGenresRepository genres, 
            IShoesRepository shoes, 
            ISizesRepository sizes, 
            ISportsRepository sports)
        {
            _context = context;
            Brands= brands;
            Genres= genres;
            Shoes= shoes;
            Sizes= sizes;
            Sports= sports;
        }
        public IBrandsRepository Brands { get; }

        public IGenresRepository Genres { get; }

        public IShoesRepository Shoes { get; }

        public ISizesRepository Sizes { get; }

        public ISportsRepository Sports { get; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void RollBack()
        {
            foreach (var item in _context.ChangeTracker.Entries())
            {
                switch (item.State)
                {
                    case EntityState.Modified:
                        item.State = EntityState.Unchanged;
                        item.CurrentValues.SetValues(item.OriginalValues);
                        break;
                    case EntityState.Added: 
                        item.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        item.State = EntityState.Unchanged;
                        break;
                }
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
