namespace OtusDbData.Models
{
    public class Student
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
