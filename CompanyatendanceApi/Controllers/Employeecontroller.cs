using api.DTO;
using api.DTO.DTO2;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;


namespace api.Controllers;

[ApiController]
[Route("CompanyatendanceApi/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;
    private readonly IMapper _mapper;

    public EmployeeController(IEmployeeService employeeService, IMapper mapper)
    {
        _employeeService = employeeService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<EmployeeDto>>> GetAllEmployee()
    {
        var employee = await _employeeService.GetAllEmployee();
        var employeeDtos = _mapper.Map<List<EmployeeDto>>(employee);
        return Ok(employeeDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EmployeeDto>> GetEmployeeById(int id)
    {
        var employee = await _employeeService.GetEmployeeById(id);
        if (employee == null)
        {
            return NotFound();
        }
        var employeeDtos = _mapper.Map<EmployeeDto>(employee);
        return Ok(employeeDtos);
    }

    [HttpPost]
    public async Task<ActionResult<EmployeeDto>> AddEmployee(EmployeeDto employeeDto)
    {
        var employee = await _employeeService.AddEmployee(employeeDto);
        var employeeDtos = _mapper.Map<EmployeeDto>(employee);
        return Ok(employeeDtos);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateEmployee(int id,[FromBody] EmployeeDto employeeDto)
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