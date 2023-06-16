using AutoMapper;

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