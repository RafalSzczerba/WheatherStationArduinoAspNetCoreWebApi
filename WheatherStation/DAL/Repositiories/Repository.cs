using Microsoft.EntityFrameworkCore;
using WheatherStation.DAL.Context;
using WheatherStation.DAL.Entities;

namespace WheatherStation.DAL.Repositiories
{
    public class Repository<T> : IBaseRepository<T> where T : class, IEntity
    {        
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _entities;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public IQueryable<T> GetAllQueryable()
        {
            return _entities.AsQueryable();
        }

        public async Task<IEnumerable<T>> FindAll()
        {
            return await _entities.ToListAsync();
        }
       
        public Task<bool> isExists(int id)
        {
            return _entities.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> Create(T entity)
        {
            await _entities.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Update(T entity)
        {
            _entities.Update(entity);
            return await Save();
        }

        public async Task<bool> Delete(T entity)
        {
            var entityToDelete = _entities.FirstOrDefault(x => x.Id == entity.Id);
            _entities.Remove(entityToDelete);
            return await Save();
        }

        public async Task<bool> Save()
        {
            var changes = await _context.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<T> FindLastData()
        {
            return await _entities.OrderBy(x => x.Id).LastOrDefaultAsync();
        }
    }
}
