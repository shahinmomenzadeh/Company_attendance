using System.Linq.Expressions;
using data;
using Microsoft.EntityFrameworkCore;

namespace BaseRepository;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    private readonly ApplicationDbContext _context;
    public DbSet<TEntity> dbset;

    public BaseRepository(ApplicationDbContext context)
    {
        _context = context;
        dbset = context.Set<TEntity>();
    }

    public virtual async Task<List<TEntity>> GetAll()
    {
        return await dbset.ToListAsync();
    }

    public virtual async Task<TEntity> GetById(int id)
    {
        return await dbset.FindAsync(id);
    }

    public virtual async Task<int> Add(TEntity entity)
    {
        await dbset.AddAsync(entity);
        return await _context.SaveChangesAsync();
    }

    public virtual async Task<int> Update(TEntity entity)
    {
        dbset.Update(entity);
        return await _context.SaveChangesAsync();
    }

    public virtual async Task<int> Delete(int id)
    {
        var entity = await dbset.FindAsync(id);
        dbset.Remove(entity);
        return await _context.SaveChangesAsync();
    }

    public virtual async Task<List<TEntity>> GetAllWithAttendance()
    {
        return await dbset.Include("Attendances").ToListAsync();
    }

    

    public async Task<List<TEntity>> GetAllWithInclude()
    {
        string includeExpression = null;
        return await dbset.Include(includeExpression).ToListAsync();
    }
}

public interface IBaseRepository<T> where T : class
{
    Task<List<T>> GetAll();
    Task<T> GetById(int id);
    Task<int> Add(T entity);
    Task<int> Update(T entity);
    Task<int> Delete(int id);
    Task<List<T>> GetAllWithAttendance();
    Task<List<T>> GetAllWithInclude();
}