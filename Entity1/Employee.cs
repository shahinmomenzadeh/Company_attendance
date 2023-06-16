using AutoMapper;
public class Employee : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public decimal Salary { get; set; }
}
