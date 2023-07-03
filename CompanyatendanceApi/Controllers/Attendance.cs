using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.DTO.DTO1;
using api.DTO.DTO2;

namespace api.Controllers
{
    [ApiController]
    [Route("CompanyatendanceApi/[controller]")]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;
        private readonly IMapper _mapper;

        public AttendanceController(IAttendanceService attendanceService, IMapper mapper)
        {
            _attendanceService = attendanceService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<AttendanceDto>>> GetAllAttendances()
        {
            var attendances = await _attendanceService.GetAllAttendancesWithAttendance();
            var attendanceDtos = _mapper.Map<List<AttendanceDto>>(attendances);
            return Ok(attendanceDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AttendanceDto>> GetAttendanceById(int id)
        {
            var attendance = await _attendanceService.GetAttendanceById(id);
            if (attendance == null)
            {
                return NotFound();
            }
            var attendanceDto = _mapper.Map<AttendanceDto>(attendance);
            return Ok(attendanceDto);
        }

        [HttpPost]
        public async Task<ActionResult<AttendanceDto>> AddAttendance(AttendanceDto2 attendanceDto2)
        {
            var attendance = _mapper.Map<Attendance>(attendanceDto2);
            await _attendanceService.AddAttendance(attendance);
            var attendanceDto = _mapper.Map<AttendanceDto>(attendance);
            return Ok(attendanceDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAttendance(int id, [FromBody] AttendanceDto2 attendanceDto2)
        {
            var attendance = _mapper.Map<Attendance>(attendanceDto2);
            try
            {
                await _attendanceService.UpdateAttendance(id, attendance);
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