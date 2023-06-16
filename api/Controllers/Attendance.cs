
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AttendanceController : ControllerBase
{
    private readonly AttendanceRepository _attendanceRepository;
    private readonly IMapper _mapper;
    
    public AttendanceController(AttendanceRepository attendanceRepository, IMapper mapper)
    {
        _attendanceRepository = attendanceRepository;
        _mapper = mapper;
    }
 [HttpGet]
        public async Task<ActionResult<List<AttendanceDto>>> GetAll()
        {
            var attendances = await _attendanceRepository.GetAll();
            var attendanceDtos = _mapper.Map<List<AttendanceDto>>(attendances);
            return Ok(attendanceDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AttendanceDto>> GetById(int id)
        {
            var attendances = await _attendanceRepository.GetById(id);
            if (attendances == null)
            {
                return NotFound();
            }
            var attendanceDto = _mapper.Map<AttendanceDto>(attendances);
            return Ok(attendanceDto);
        }

        // [HttpPost]
        // public async Task<ActionResult<AttendanceDto>> Add(AttendanceDto attendanceDto)
        // {
        //     var attendance = _mapper.Map<Attendance>(attendanceDto);
        //     await _attendanceRepository.Add(attendance);
        //     return Ok(_mapper.Map<AttendanceDto>(attendance));
        // }
        [HttpPost]
        public async Task<ActionResult<AttendanceDto>> Add(AttendanceDto attendanceDto)
        {
            var attendance = _mapper.Map<Attendance>(attendanceDto);
            ReflectionHelper.SetPropertyValue(attendance, "EmployeeId", 1);
            await _attendanceRepository.Add(attendance);
            return Ok(_mapper.Map<AttendanceDto>(attendance));
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, AttendanceDto attendanceDto)
        {
            if (id != attendanceDto.Id)
            {
                return BadRequest();
            }
            var existingAttendance = await _attendanceRepository.GetById(id);
            if (existingAttendance == null)
            {
                return NotFound();
            }
            var attendance = _mapper.Map<Attendance>(attendanceDto);
            await _attendanceRepository.Update(attendance);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existingAttendance = await _attendanceRepository.GetById(id);
            if (existingAttendance == null)
            {
                return NotFound();
            }
            await _attendanceRepository.Delete(id);
            return NoContent();
        }
        
    }
