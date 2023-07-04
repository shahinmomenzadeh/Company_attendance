using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.DTO.DTO1;
using api.DTO.DTO2;
using Microsoft.EntityFrameworkCore;

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
            try
            {
                var attendances = await _attendanceService.GetAllAttendances();
                var attendanceDtos = _mapper.Map<List<AttendanceDto>>(attendances);
                return Ok(attendanceDtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AttendanceDto>> GetAttendanceById(int id)
        {
            try
            {
                var attendance = await _attendanceService.GetAttendanceById(id);
                if (attendance == null)
                {
                    return NotFound();
                }
                var attendanceDto = _mapper.Map<AttendanceDto>(attendance);
                return Ok(attendanceDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<AttendanceDto>> AddAttendance(AttendanceDto attendanceDto)
        {
            try
            {
                var attendance = _mapper.Map<Attendance>(attendanceDto);
                await _attendanceService.AddAttendance(attendance);
                var attendanceDto2 = _mapper.Map<AttendanceDto>(attendance);
                return Ok(attendanceDto2);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAttendance(int id, [FromBody] AttendanceDto attendanceDto)
        {
            try
            {
                var attendance = _mapper.Map<Attendance>(attendanceDto);
                await _attendanceService.UpdateAttendance(id, attendance);
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
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
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}