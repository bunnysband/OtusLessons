using OtusDbData.Contracts;

namespace OtusDbData.Interfaces
{
    public interface IOtusDataProvider
    {
        IEnumerable<CourseDto> GetAllCourses();

        IEnumerable<LessonDto> GetAllLessons();

        IEnumerable<UserDto> GetAllUsers();

        void AddUser(UserDto user);
    }
}