﻿using Microsoft.EntityFrameworkCore;
using RealEstateweblearning.Data;

namespace RealEstateweblearning.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly RealEstateDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(RealEstateDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task SaveAsync() => await _context.SaveChangesAsync();


        public IQueryable<T> Query()
        {
            return _dbSet.AsQueryable();
        }
    }
}
