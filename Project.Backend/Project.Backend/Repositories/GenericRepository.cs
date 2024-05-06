using Microsoft.EntityFrameworkCore;
using Project.Backend.Contracts;
using Project.Backend.Entities;
using Project.Backend.Entities.Common;

namespace Project.Backend.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        ProjectDBContext _context;
        public GenericRepository(ProjectDBContext context)
        {
            _context = context;
        }
        public virtual async Task<int> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
        public virtual async Task<bool> DeleteAsync(T entity)
        {
            _context.Remove(entity);
            var d = await _context.SaveChangesAsync();
            return d > 0 ? true : false;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().Where(q => !q.IsDeleted).ToListAsync();

        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>()
               .AsNoTracking()
               .FirstOrDefaultAsync(q => q.Id == id && !q.IsDeleted);

        }

        public virtual async Task AddOrUpdate(T entity)
        {
            if (entity.Id.Equals(Guid.Empty))
            {
                // Add new entity
                await AddAsync(entity);
            }
            else
            {
                // Update existing entity
                await UpdateAsync(entity);
            }
        }
    }
}
