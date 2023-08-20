using AutoMapper;
using OtusDbData.Data.Entities;
using OtusDbData.Service.DTO;

namespace OtusDbData.Service;

public class OtusDbDataProfile : Profile
{
    public OtusDbDataProfile()
    {
        CreateMap<Course, CourseDto>();
        CreateMap<Lesson, LessonDto>();
        CreateMap<User, UserDto>().ReverseMap();
    }
}
