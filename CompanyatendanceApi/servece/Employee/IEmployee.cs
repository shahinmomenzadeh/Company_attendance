using System.Collections.Generic;
using System.Threading.Tasks;
using api.DTO.DTO1;
using api.DTO.DTO2;

public interface IEmployeeService
{
    Task<List<EmployeeDto>> GetAllEmployees();
    Task<EmployeeDto> GetEmployeeById(int id);
    Task<EmployeeDto> AddEmployee(EmployeeDto employeeDto);
    Task UpdateEmployee(int id, EmployeeDto employeeDto);
    Task DeleteEmployee(int id);
    
}