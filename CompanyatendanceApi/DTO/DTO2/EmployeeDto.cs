namespace api.DTO.DTO2;

public class EmployeeDto: BaseDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public decimal Salary { get; set; }
}