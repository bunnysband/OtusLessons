using Microsoft.EntityFrameworkCore;
using OtusDbData.Models;

namespace OtusDbData.EF
{
    public class OtusDataDbRepository : IDataRepository
    {
        private readonly DbContext _dbContext;
        public OtusDataDbRepository(DbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public void AddUser(User user)
        {
            _dbContext.Set<User>().Add(user);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Course> GetAllCourses() 
            =>_dbContext.Set<Course>()
            .Include(c => c.Lessons)
            .Include(c => c.CreatedBy)
            .Include(c => c.LastUpdatedBy)
            .ToList();

        public IEnumerable<Lesson> GetAllLessons() => _dbContext.Set<Lesson>().Include(l => l.Course).ToList();

        public IEnumerable<User> GetAllUsers() => _dbContext.Set<User>().ToList();
    }
}
