using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.DTO.DTO1;


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
            var attendances = await _attendanceService.GetAllAttendances();
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
        public async Task<ActionResult<AttendanceDto>> AddAttendance( AttendanceDto attendanceDto)
        {
            var attendance = await _attendanceService.AddAttendance(attendanceDto);
            attendanceDto = _mapper.Map<AttendanceDto>(attendance);
            return Ok(attendanceDto);
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