using OtusDbData.Models;

namespace OtusDbData.Interfaces
{
    public interface IOtusDataProvider
    {
        IEnumerable<Course> GetAllCourses();

        IEnumerable<Lesson> GetAllLessons();

        IEnumerable<User> GetAllUsers();

        void AddUser(User user);
    }
}