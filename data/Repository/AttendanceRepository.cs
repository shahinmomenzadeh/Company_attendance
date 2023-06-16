using Microsoft.EntityFrameworkCore;

    public class AttendanceRepository :  IRepository<Attendance>
    {
        private readonly ApplicationDbContext _context;

        public AttendanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    public async Task<List<Attendance>> GetAll()
    {
        return await _context.Set<Attendance>().ToListAsync();
    }

    public async Task<Attendance> GetById(int id)
    {
        return await _context.Set<Attendance>().FindAsync(id);
    }

    public async Task<int> Add(Attendance entity)
    {
        await _context.Set<Attendance>().AddAsync(entity);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> Update(Attendance entity)
    {
        _context.Set<Attendance>().Update(entity);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> Delete(int id)
    {
        var entity = await _context.Set<Attendance>().FindAsync(id);
        _context.Set<Attendance>().Remove(entity);
        return await _context.SaveChangesAsync();
    }
}

