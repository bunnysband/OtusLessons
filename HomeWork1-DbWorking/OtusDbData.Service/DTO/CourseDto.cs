using OtusDbData.Data.Enums;

namespace OtusDbData.Service.DTO;

public class CourseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public UserDto CreatedBy { get; set; }
    public DateTime LastUpdatedDate { get; set; }
    public UserDto LastUpdatedBy { get; set; }

    public DifficultyLevel Level { get; set; }

    public ICollection<LessonDto> Lessons { get; set; } = new List<LessonDto>();
}