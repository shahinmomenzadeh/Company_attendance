using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.DTO;
using data.Repository;
using Entity1;

namespace api.Controllers
{
    [ApiController]
    [Route("CompanyatendanceApi/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IBaseRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeController(IBaseRepository<Employee> employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeDto>>> GetAll()
        {
            var employees = await _employeeRepository.GetAll();
            var employeeDtos = _mapper.Map<List<EmployeeDto>>(employees);
            return Ok(employeeDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetById(int id)
        {
            var employee = await _employeeRepository.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return Ok(employeeDto);
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> Add(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            await _employeeRepository.Add(employee);
            return Ok(_mapper.Map<EmployeeDto>(employee));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, EmployeeDto employeeDto)
        {
            if (id != employeeDto.Id)
            {
                return BadRequest();
            }
            var existingEmployee = await _employeeRepository.GetById(id);
            if (existingEmployee == null)
            {
                return NotFound();
            }
            _mapper.Map(employeeDto, existingEmployee);
            await _employeeRepository.Update(existingEmployee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existingEmployee = await _employeeRepository.GetById(id);
            if (existingEmployee == null)
            {
                return NotFound();
            }
            await _employeeRepository.Delete(id);
            return NoContent();
        }
    }
}