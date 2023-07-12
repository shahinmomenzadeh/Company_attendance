using System.Collections.Generic;
using System.Threading.Tasks;
using api.DTO.DTO1;
using api.DTO.DTO2;

public interface IEmployeeService
{
    Task<List<EmployeeSelectDto>> GetAllEmployees();
    Task<EmployeeSelectDto> GetEmployeeById(int id);
    Task<EmployeeSelectDto> AddEmployee(EmployeeDto employeeDto);
    Task UpdateEmployee(int id, EmployeeDto employeeDto);
    Task DeleteEmployee(int id);
    
}