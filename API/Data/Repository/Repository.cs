using API.Data.Contracts.Repositories;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly RepositoryContext _context;

        public Repository(RepositoryContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll()
        {
            try
            {
                return _context.Set<T>();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Log the error
                throw new Exception($"Couldn't retrieve data from Database{ex.Message}");
            }
        }

        public async Task<T> AddAsync(T entity)
        {
            ArgumentNullException.ThrowIfNull(entity); try
            {
                await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Log the error
                throw new Exception($"Couldn't add entity to Database{ex.Message}");
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            ArgumentNullException.ThrowIfNull(entity); try
            {
                _context.Set<T>().Update(entity);
                await _context.SaveChangesAsync();
                
                return entity;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Log the error
                throw new Exception($"Couldn't update entity in Database{ex.Message}");
            }
        }

        public void Delete(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Log the error
                throw new Exception($"Couldn't delete entity from Database{ex.Message}");
            }
        }
    }
}