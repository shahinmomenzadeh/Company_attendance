using api.DTO;

public class AttendanceSelectDto : BaseDto
{
   
    public string EmployeeName { get; set; }
    public DateTime Date { get; set; }
    public bool IsPresent { get; set; }
}