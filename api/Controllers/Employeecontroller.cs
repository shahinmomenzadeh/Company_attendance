using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly EmployeeRepository _employeeRepository;

    public EmployeeController(EmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<Employee>>> GetAllEmployees()
    {
        var employees = await _employeeRepository.GetAllEmployees();
        return Ok(employees);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Employee>> GetEmployeeById(int id)
    {
        var employee = await _employeeRepository.GetEmployeeById(id);
        if (employee == null)
        {
            return NotFound();
        }
        return Ok(employee);
    }

    [HttpPost]
    public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
    {
        await _employeeRepository.AddEmployee(employee);
        return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult>UpdateEmployee(int id, Employee employee)
    {
        if (id != employee.Id)
        {
            return BadRequest();
        }
        var existingEmployee = await _employeeRepository.GetEmployeeById(id);
        if (existingEmployee == null)
        {
            return NotFound();
        }
        await _employeeRepository.UpdateEmployee(employee);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteEmployee(int id)
    {
        var existingEmployee = await _employeeRepository.GetEmployeeById(id);
        if (existingEmployee == null)
        {
            return NotFound();
        }
        await _employeeRepository.DeleteEmployee(id);
        return NoContent();
    }
}