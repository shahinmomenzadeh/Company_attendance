using model;
using Microsoft.AspNetCore.Mvc;
using api.DTO.DTO1;

namespace api.Controllers
{
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
        public async Task<ActionResult<List<AttendanceSelectDto>>> GetAllAttendances()
        {
            var attendances = await _attendanceService.GetAllAttendances();
            var attendanceSelectDtos = attendances.Select(a => new AttendanceSelectDto
            {
                Id = a.Id,
                EmployeeId = a.EmployeeId,
                EntryTime = a.EntryTime,
                ExitTime = a.ExitTime
            }).ToList();
            return Ok(attendanceSelectDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AttendanceSelectDto>> GetAttendanceById(int id)
        {
            var attendance = await _attendanceService.GetAttendanceById(id);
            if (attendance == null)
            {
                return NotFound();
            }
            var attendanceSelectDto = new AttendanceSelectDto
            {
                Id = attendance.Id,
                EmployeeId = attendance.EmployeeId,
                EntryTime = attendance.EntryTime,
                ExitTime = attendance.ExitTime
            };
            return Ok(attendanceSelectDto);
        }

        [HttpPost]
        public async Task<ActionResult<AttendanceSelectDto>> AddAttendance([FromBody] AttendanceDto attendanceDto)
        {
            var attendance = await _attendanceService.AddAttendance(attendanceDto);
            var attendanceSelectDto = new AttendanceSelectDto
            {
                Id = attendance.Id,
                EmployeeId = attendance.EmployeeId,
                EntryTime = attendance.EntryTime,
                ExitTime = attendance.ExitTime
            };
            return Ok(attendanceSelectDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAttendance(int id, [FromBody] AttendanceDto attendanceDto)
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
}