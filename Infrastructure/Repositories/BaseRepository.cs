using Application.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BaseRepository<T> : IAsyncReposiotry<T> where T : class
    {
        private readonly DataContext _context;

        public BaseRepository(DataContext context)
        {
            _context = context;
        }
        private async Task Commit()=> await _context.SaveChangesAsync();

        public virtual async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);

        public virtual async Task<T> GetByNameAsync(string Name) => await _context.Set<T>().FindAsync(Name);

        public virtual async Task<IReadOnlyList<T>> ListAllAsync() => await _context.Set<T>().AsNoTracking().ToListAsync();

        public virtual async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await Commit();
            return entity;
        }


        public virtual async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await Commit();
        }



        public async Task<T> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await Commit();
            return entity;
        }
    }
}
