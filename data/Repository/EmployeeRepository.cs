using Microsoft.EntityFrameworkCore;

public class EmployeeRepository : IRepository<Employee>
{
    private readonly ApplicationDbContext _context;

    public EmployeeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Employee>> GetAll()
    {
        return await _context.Set<Employee>().ToListAsync();
    }

    public async Task<Employee> GetById(int id)
    {
        return await _context.Set<Employee>().FindAsync(id);
    }

    public async Task<int> Add(Employee entity)
    {
        await _context.Set<Employee>().AddAsync(entity);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> Update(Employee entity)
    {
        _context.Set<Employee>().Update(entity);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> Delete(int id)
    {
        var entity = await _context.Set<Employee>().FindAsync(id);
        _context.Set<Employee>().Remove(entity);
        return await _context.SaveChangesAsync();
    }
}

public interface IRepository<T> where T : BaseEntity
{
    Task<List<T>> GetAll();
    Task<T> GetById(int id);
    Task<int> Add(T entity);
    Task<int> Update(T entity);
    Task<int> Delete(int id);
}