
using api.DTO;
using api.Reflection;
using AutoMapper;
using data.Repository;
using Microsoft.AspNetCore.Mvc;
using model;

namespace api.Controllers;

[ApiController]
[Route("CompanyatendanceApi/[controller]")]
public class AttendanceController : ControllerBase
{
    private readonly IBaseRepository<Attendance> _attendanceRepository;
    private readonly IMapper _mapper;
    
    public AttendanceController(IBaseRepository<Attendance> attendanceRepository, IMapper mapper)
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

        [HttpPost]
        public async Task<ActionResult<AttendanceDto>> Add(AttendanceDto attendanceDto)
        {
            var attendance = _mapper.Map<Attendance>(attendanceDto);
            await _attendanceRepository.Add(attendance);
            return Ok(_mapper.Map<AttendanceDto>(attendance));
        }
        // [HttpPost]
        // public async Task<ActionResult<AttendanceDto>> Add(AttendanceDto attendanceDto)
        // {
        //     var attendance = _mapper.Map<Attendance>(attendanceDto);
        //     ReflectionHelper.SetPropertyValue(attendance,"EmployeeId", 1);
        //     await _attendanceRepository.Add(attendance);
        //     return Ok(_mapper.Map<AttendanceDto>(attendance));
        // }


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
            _mapper.Map(attendanceDto,existingAttendance);
            await _attendanceRepository.Update(existingAttendance);
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
