using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.DTO.DTO2;
using AutoMapper;
using BaseRepository;
using Microsoft.AspNetCore.Mvc;
using model;

namespace Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IBaseRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;
        private IEmployeeService _employeeServiceImplementation;

        public EmployeeService(IBaseRepository<Employee> employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<List<EmployeeSelectDto>> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetAll();
            var employeeDtos = _mapper.Map<List<EmployeeSelectDto>>(employees);
            return employeeDtos;
        }

        public async Task<EmployeeSelectDto> GetEmployeeById(int id)
        {
            var employee = await _employeeRepository.GetById(id);
            if (employee == null)
            {
                return null;
            }
            var employeeDto = _mapper.Map<EmployeeSelectDto>(employee);
            return employeeDto;
        }

        public async Task<EmployeeSelectDto> AddEmployee(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            await _employeeRepository.Add(employee);
            return _mapper.Map<EmployeeSelectDto>(employee);
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
}