using api.DTO.DTO1;
using api.DTO.DTO2;



namespace AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Employee, EmployeeSelectDto>().ReverseMap();
            CreateMap<Attendance, AttendanceDto>().ReverseMap();
            CreateMap<Attendance, AttendanceSelectDto>().ReverseMap();
        }
    }
}