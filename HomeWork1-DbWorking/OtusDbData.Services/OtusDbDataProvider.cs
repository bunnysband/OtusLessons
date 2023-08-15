using AutoMapper;
using OtusDbData.Contracts;
using OtusDbData.Interfaces;
using OtusDbData.Models;
using OtusDbData.Services.Exceptions;

namespace OtusDbData.Services
{
    public class OtusDbDataProvider : IOtusDataProvider
    {
        private readonly IDataRepository _dataRepository;
        private readonly IMapper _mapper;
        public OtusDbDataProvider(IMapper mapper, IDataRepository dataRepository) 
        {
            _dataRepository = dataRepository;
            _mapper = mapper;
        }

        public void AddUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            if (_dataRepository.GetAllUsers().Any(u => u.Email == user.Email))
                throw new AddUserException($"User with email {user.Email} is already exist");
            _dataRepository.AddUser(user);
        }

        public IEnumerable<CourseDto> GetAllCourses() => _mapper.Map<List<CourseDto>>(_dataRepository.GetAllCourses());

        public IEnumerable<LessonDto> GetAllLessons() => _mapper.Map<List<LessonDto>>(_dataRepository.GetAllLessons());

        public IEnumerable<UserDto> GetAllUsers() => _mapper.Map<List<UserDto>>(_dataRepository.GetAllUsers());
    }
}