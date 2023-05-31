using Microsoft.EntityFrameworkCore;

namespace data.Repository;
public class AttendanceRepository
{
    private readonly ApplicationDbContext _context;

    public AttendanceRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Attendance>> GetAllAttendances()
    {
        return await _context.Attendances.ToListAsync();
    }

    public async Task<Attendance> GetAttendanceById(int id)
    {
        return await _context.Attendances.FindAsync(id);
    }

    public async Task<int> AddAttendance(Attendance attendance)
    {
        await _context.Attendances.AddAsync(attendance);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> UpdateAttendance(Attendance attendance)
    {
        _context.Attendances.Update(attendance);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteAttendance(int id)
    {
        var attendance = await _context.Attendances.FindAsync(id);
        _context.Attendances.Remove(attendance);
        return await _context.SaveChangesAsync();
    }
}