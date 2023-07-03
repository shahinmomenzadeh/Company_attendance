using api.DTO;
using api.DTO.DTO2;
using Microsoft.AspNetCore.Mvc;


namespace api.Controllers;

[ApiController]
[Route("CompanyatendanceApi/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<ActionResult<List<EmployeeDto>>> GetAllEmployee()
    {
        var employee = await _employeeService.GetAllEmployee();
        return Ok(employee);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EmployeeDto>> GetEmployeeById(int id)
    {
        var employee = await _employeeService.GetEmployeeById(id);
        if (employee == null)
        {
            return NotFound();
        }
        return Ok(employee);
    }

    [HttpPost]
    public async Task<ActionResult<EmployeeDto>> AddEmployee(EmployeeDto employeeDto)
    {
        var employee = await _employeeService.AddEmployee(employeeDto);
        return Ok(employee);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateEmployee(int id, EmployeeDto employeeDto)
    {
        try
        {
            await _employeeService.UpdateEmployee(id, employeeDto);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteEmployee(int id)
    {
        try
        {
            await _employeeService.DeleteEmployee(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    
        
}