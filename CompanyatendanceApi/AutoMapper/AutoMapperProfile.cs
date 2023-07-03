using api.DTO.DTO1;
using api.DTO.DTO2;
using Entity1;
using model;


namespace AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
            CreateMap<Attendance, AttendanceDto>();
            //CreateMap<Attendance, AttendanceSelectDto>();
            CreateMap<AttendanceDto, Attendance>();
        }
    }
}