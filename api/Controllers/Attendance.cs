using data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AttendanceController : ControllerBase
{
    private readonly AttendanceRepository _attendanceRepository;

    public AttendanceController(AttendanceRepository attendanceRepository)
    {
        _attendanceRepository = attendanceRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<Attendance>>> GetAllAttendances()
    {
        var attendances = await _attendanceRepository.GetAllAttendances();
        return Ok(attendances);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Attendance>> GetAttendanceById(int id)
    {
        var attendance = await _attendanceRepository.GetAttendanceById(id);
        if (attendance == null)
        {
            return NotFound();
        }
        return Ok(attendance);
    }

    [HttpPost]
    public async Task<ActionResult<Attendance>> AddAttendance(Attendance attendance)
    {
        await _attendanceRepository.AddAttendance(attendance);
        return CreatedAtAction(nameof(GetAttendanceById), new { id = attendance.Id }, attendance);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateAttendance(int id, Attendance attendance)
    {
        if (id != attendance.Id)
        {
            return BadRequest();
        }
        var existingAttendance = await _attendanceRepository.GetAttendanceById(id);
        if (existingAttendance == null)
        {
            return NotFound();
        }
        await _attendanceRepository.UpdateAttendance(attendance);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAttendance(int id)
    {
        var existingAttendance = await _attendanceRepository.GetAttendanceById(id);
        if (existingAttendance == null)
        {
            return NotFound();
        }
        await _attendanceRepository.DeleteAttendance(id);
        return NoContent();
    }
}