using AutoMapper;
using Entity1;
using model;

namespace api.DTO;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Employee, EmployeeDto>();
        CreateMap<EmployeeDto, Employee>();
        CreateMap<Attendance, AttendanceDto>();
        CreateMap<AttendanceDto, Attendance>();
    }
}