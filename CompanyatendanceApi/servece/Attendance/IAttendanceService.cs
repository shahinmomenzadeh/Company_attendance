using api.DTO.DTO1;

public interface IAttendanceService
{
    Task<List<AttendanceDto>> GetAllAttendances();
    Task<AttendanceDto> GetAttendanceById(int id);
    Task<AttendanceDto> AddAttendance(Attendance attendanceDto);
    Task UpdateAttendance(int id, Attendance attendanceDto);
    Task DeleteAttendance(int id);
    Task<List<AttendanceDto>> GetAllAttendancesWithAttendance();
}