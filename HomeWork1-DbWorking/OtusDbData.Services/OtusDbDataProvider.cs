using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OtusDbData.Contracts;
using OtusDbData.EF;
using OtusDbData.Interfaces;
using OtusDbData.Models;
using OtusDbData.Services.Exceptions;

namespace OtusDbData.Services
{
    public class OtusDbDataProvider : IOtusDataProvider
    {
        private readonly OtusDataDbContext _dbContext;
        private readonly IMapper _mapper;
        public OtusDbDataProvider(IMapper mapper, OtusDataDbContext dbContext) 
        { 
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void AddUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            if (_dbContext.Users.Any(u => u.Email == user.Email))
                throw new AddUserException($"User with email {user.Email} is already exist");
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public IEnumerable<CourseDto> GetAllCourses()
        {
            var courses = _dbContext.Courses
            .Include(c => c.Lessons)
            .Include(c => c.CreatedBy)
            .Include(c => c.LastUpdatedBy)
            .ToList();

            return _mapper.Map<List<CourseDto>>(courses);
        }

        public IEnumerable<LessonDto> GetAllLessons()
        {
            var lessons = _dbContext.Lessons.Include(l => l.Course).ToList();

            return _mapper.Map<List<LessonDto>>(lessons);
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            var users = _dbContext.Users.ToList();

            return _mapper.Map<List<UserDto>>(users);
        }
    }
}