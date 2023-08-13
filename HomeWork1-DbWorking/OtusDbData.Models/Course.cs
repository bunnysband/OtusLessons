using OtusDbData.Models.Enums;

namespace OtusDbData.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set;}
        public int CreatedById { get; set; }
        public User CreatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set;}    
        public User? LastUpdatedBy { get; set; }

        public DifficultyLevel Level { get; set; }

        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
