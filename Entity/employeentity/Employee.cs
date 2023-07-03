using model;

public class Employee : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public ICollection<Attendance> Attendances { get; set; }
}