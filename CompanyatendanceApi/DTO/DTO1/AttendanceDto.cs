using AutoMapper;
namespace api.DTO.DTO1;

public class AttendanceDto: BaseDto
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public DateTime EntryTime { get; set; }
    public DateTime ExitTime { get; set; }
}