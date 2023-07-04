using api.DTO.DTO1;
using api.DTO.DTO2;



namespace AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
            CreateMap<Attendance, AttendanceDto>();
            CreateMap<Attendance, AttendanceDto2>();
            CreateMap<AttendanceDto2, Attendance>();
            CreateMap<AttendanceDto, Attendance>();
        }
    }
}