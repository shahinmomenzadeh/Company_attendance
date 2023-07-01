﻿using api.DTO;

public interface IEmployeeService
{
    Task<List<EmployeeDto>> GetAllEmployee();
    Task<EmployeeDto> GetEmployeeById(int id);
    Task<EmployeeDto> AddEmployee(EmployeeDto employeeDto);
    Task UpdateEmployee(int id, EmployeeDto employeeDto);
    Task DeleteEmployee(int id);
    
}