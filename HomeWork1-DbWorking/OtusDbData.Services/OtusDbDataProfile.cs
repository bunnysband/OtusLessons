using AutoMapper;
using OtusDbData.Contracts;
using OtusDbData.Models;

namespace OtusDbData.Services
{
    public class OtusDbDataProfile : Profile
    {
        public OtusDbDataProfile()
        {
            CreateMap<Course, CourseDto>();
            CreateMap<Lesson, LessonDto>();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
