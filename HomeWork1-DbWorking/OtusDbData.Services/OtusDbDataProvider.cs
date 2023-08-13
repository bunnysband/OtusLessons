using Microsoft.EntityFrameworkCore;
using OtusDbData.EF;
using OtusDbData.Interfaces;
using OtusDbData.Models;
using OtusDbData.Services.Exceptions;

namespace OtusDbData.Services
{
    public class OtusDbDataProvider : IOtusDataProvider
    {
        private readonly OtusDataDbContext _dbContext;
        public OtusDbDataProvider(OtusDataDbContext dbContext) 
        { 
            _dbContext = dbContext;
        }

        public void AddUser(User user)
        {
            if (_dbContext.Users.Any(u => u.Email == user.Email))
                throw new AddUserException($"User with email {user.Email} is already exist");
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Course> GetAllCourses() 
            =>_dbContext.Courses
            .Include(c => c.Lessons)
            .Include(c => c.CreatedBy)
            .Include(c => c.LastUpdatedBy)
            .ToList();

        public IEnumerable<Lesson> GetAllLessons() => _dbContext.Lessons.Include(l => l.Course).ToList();

        public IEnumerable<User> GetAllUsers() => _dbContext.Users.ToList();
    }
}