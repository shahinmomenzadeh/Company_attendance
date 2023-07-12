public class EmployeeSelectDto
{
    public int Id { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ICollection<Attendance> Attendances { get; set; }
}