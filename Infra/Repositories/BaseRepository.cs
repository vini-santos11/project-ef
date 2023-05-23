using Domain.Interfaces.Repositories;

namespace Infra.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    //private readonly DbContext _dbContext;
    //private readonly DbSet<TEntity> _dbSet;

    public BaseRepository()//DbContext dbContext)
    {
        //_dbContext = dbContext;
        //_dbSet = _dbContext.Set<TEntity>();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return null;
        //return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return null;
        //return await _dbSet.ToListAsync();
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        //await _dbSet.AddAsync(entity);
        //await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        //_dbContext.Entry(entity).State = EntityState.Modified;
        //await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        //_dbSet.Remove(entity);
        //await _dbContext.SaveChangesAsync();
        return entity;
    }
}