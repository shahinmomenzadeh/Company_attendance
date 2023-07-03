using AutoMapper;
using BaseRepository;
using model;
using api.DTO.DTO1;

namespace Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IBaseRepository<Attendance> _attendanceRepository;
        private readonly IMapper _mapper;

        public AttendanceService(IBaseRepository<Attendance> attendanceRepository, IMapper mapper)
        {
            _attendanceRepository = attendanceRepository;
            _mapper = mapper;
        }

        public async Task<List<AttendanceDto>> GetAllAttendances()
        {
            var attendances = await _attendanceRepository.GetAll();
            var attendanceDtos = _mapper.Map<List<AttendanceDto>>(attendances);
            return attendanceDtos;
        }

        public async Task<AttendanceDto> GetAttendanceById(int id)
        {
            var attendance = await _attendanceRepository.GetById(id);
            if (attendance == null)
            {
                return null;
            }
            var attendanceDto = _mapper.Map<AttendanceDto>(attendance);
            return attendanceDto;
        }

        public async Task<AttendanceDto> AddAttendance(AttendanceDto attendanceDto)
        {
            var attendance = _mapper.Map<Attendance>(attendanceDto);
            await _attendanceRepository.Add(attendance);
            return _mapper.Map<AttendanceDto>(attendance);
        }

        public async Task UpdateAttendance(int id, AttendanceDto attendanceDto)
        {
            var existingAttendance = await _attendanceRepository.GetById(id);
            if (existingAttendance == null)
            {
                throw new Exception("Attendance not found.");
            }
            _mapper.Map(attendanceDto, existingAttendance);
            await _attendanceRepository.Update(existingAttendance);
        }

        public async Task DeleteAttendance(int id)
        {
            var existingAttendance = await _attendanceRepository.GetById(id);
            if (existingAttendance == null)
            {
                throw new Exception("Attendance not found.");
            }
            await _attendanceRepository.Delete(id);
        }
    }
}