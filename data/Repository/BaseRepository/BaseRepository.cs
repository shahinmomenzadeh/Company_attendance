using data;
using Microsoft.EntityFrameworkCore;

namespace BaseRepository;

public class BaseRepository<TEntity> :IBaseRepository<TEntity> where TEntity : class
{
    private readonly ApplicationDbContext _context;
    public  DbSet<TEntity> dbset;

    public BaseRepository(ApplicationDbContext context)
    {
        _context = context;
        dbset = context.Set<TEntity>();
    }

    public Task<List<TEntity>> GetAll()
    {
        return dbset.ToListAsync();
    }

    public async Task<TEntity> GetById(int id)
    {
        return await dbset.FindAsync(id);
    }

    public async Task<int> Add(TEntity entity)
    {
        await dbset.AddAsync(entity);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> Update(TEntity entity)
    {
         dbset.Update(entity);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> Delete(int id)
    {
        var entity = await dbset.FindAsync(id);
        dbset.Remove(entity);
        return await _context.SaveChangesAsync();
    }
}

public interface IBaseRepository<T> where T :  class
{
    Task<List<T>> GetAll();
    Task<T> GetById(int id);
    Task<int> Add(T entity);
    Task<int> Update(T entity);
    Task<int> Delete(int id);
}