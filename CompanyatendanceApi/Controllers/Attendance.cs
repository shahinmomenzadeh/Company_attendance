using api.DTO;
using Microsoft.AspNetCore.Mvc;


namespace api.Controllers;

[ApiController]
[Route("CompanyatendanceApi/[controller]")]
public class AttendanceController : ControllerBase
{
    private readonly IAttendanceService _attendanceService;

    public AttendanceController(IAttendanceService attendanceService)
    {
        _attendanceService = attendanceService;
    }

    [HttpGet]
    public async Task<ActionResult<List<AttendanceDto>>> GetAllAttendances()
    {
        var attendances = await _attendanceService.GetAllAttendances();
        return Ok(attendances);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AttendanceDto>> GetAttendanceById(int id)
    {
        var attendance = await _attendanceService.GetAttendanceById(id);
        if (attendance == null)
        {
            return NotFound();
        }
        return Ok(attendance);
    }

    [HttpPost]
    public async Task<ActionResult<AttendanceDto>> AddAttendance(AttendanceDto attendanceDto)
    {
        var attendance = await _attendanceService.AddAttendance(attendanceDto);
        return Ok(attendance);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateAttendance(int id, AttendanceDto attendanceDto)
    {
        try
        {
            await _attendanceService.UpdateAttendance(id, attendanceDto);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAttendance(int id)
    {
        try
        {
            await _attendanceService.DeleteAttendance(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    
        
    }
