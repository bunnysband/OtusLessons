using OtusDbData.Service.DTO;

namespace OtusDbData.Service;

public interface IOtusDataProvider
{
    IEnumerable<CourseDto> GetAllCourses();

    IEnumerable<LessonDto> GetAllLessons();

    IEnumerable<UserDto> GetAllUsers();

    void AddUser(UserDto user);
}