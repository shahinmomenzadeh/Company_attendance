using Microsoft.EntityFrameworkCore;

public class EmployeeRepository
{
    private readonly ApplicationDbContext _context;

    public EmployeeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Employee>> GetAllEmployees()
    {
        return await _context.Employees.ToListAsync();
    }

    public async Task<Employee> GetEmployeeById(int id)
    {
        return await _context.Employees.FindAsync(id);
    }

    public async Task<int> AddEmployee(Employee employee)
    {
        await _context.Employees.AddAsync(employee);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> UpdateEmployee(Employee employee)
    {
        _context.Employees.Update(employee);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteEmployee(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        _context.Employees.Remove(employee);
        return await _context.SaveChangesAsync();
    }
}