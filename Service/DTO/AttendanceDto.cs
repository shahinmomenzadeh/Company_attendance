namespace api.DTO;

public class AttendanceDto
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public DateTime EntryTime { get; set; }
    public DateTime ExitTime { get; set; }
}