using api.DTO;
using AutoMapper;
using data.Repository;
using Entity1;
using model;

public class EmployeeService : IEmployeeService
{
    private readonly IBaseRepository<Employee> _employeeRepository;
    private readonly IMapper _mapper;

    public EmployeeService(IBaseRepository<Employee> employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }

    public async Task<List<EmployeeDto>> GetAllEmployee()
    {
        var employee = await _employeeRepository.GetAll();
        var employeeDtos = _mapper.Map<List<EmployeeDto>>(employee);
        return employeeDtos;
    }

    public async Task<EmployeeDto> GetEmployeeById(int id)
    {
        var employee = await _employeeRepository.GetById(id);
        if (employee == null)
        {
            return null;
        }
        var employeeDto = _mapper.Map<EmployeeDto>(employee);
        return employeeDto;
    }

    public async Task<EmployeeDto> AddEmployee(EmployeeDto employeeDto)
    {
        var employee = _mapper.Map<Employee>(employeeDto);
        await _employeeRepository.Add(employee);
        return _mapper.Map<EmployeeDto>(employee);
    }

    public async Task UpdateEmployee(int id, EmployeeDto employeeDto)
    {
        var existingEmployee = await _employeeRepository.GetById(id);
        if (existingEmployee == null)
        {
            throw new Exception("Employee not found.");
        }
        _mapper.Map(employeeDto, existingEmployee);
        await _employeeRepository.Update(existingEmployee);
    }

    public async Task DeleteEmployee(int id)
    {
        var existingEmployee = await _employeeRepository.GetById(id);
        if (existingEmployee == null)
        {
            throw new Exception("Employee not found.");
        }
        await _employeeRepository.Delete(id);
    }
}