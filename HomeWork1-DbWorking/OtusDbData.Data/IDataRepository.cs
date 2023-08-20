using OtusDbData.Data.Entities;

namespace OtusDbData.Data;

public interface IDataRepository
{
    IEnumerable<Course> GetAllCourses();
    IEnumerable<Lesson> GetAllLessons();

    IEnumerable<User> GetAllUsers();
    void AddUser(User user);
}
