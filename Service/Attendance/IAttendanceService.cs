using api.DTO;

public interface IAttendanceService
{
    Task<List<AttendanceDto>> GetAllAttendances();
    Task<AttendanceDto> GetAttendanceById(int id);
    Task<AttendanceDto> AddAttendance(AttendanceDto attendanceDto);
    Task UpdateAttendance(int id, AttendanceDto attendanceDto);
    Task DeleteAttendance(int id);
}