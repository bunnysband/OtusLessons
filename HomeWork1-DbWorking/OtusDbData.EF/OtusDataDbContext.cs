using Microsoft.EntityFrameworkCore;
using OtusDbData.Models;
using OtusDbData.Models.Enums;

namespace OtusDbData.EF
{
    public class OtusDataDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<Lesson> Lessons { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Level> Levels { get; set; } = null!;
        public OtusDataDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LevelConfiguration());
            modelBuilder.ApplyConfiguration(new CourseDataConfiguration());
            modelBuilder.ApplyConfiguration(new LessonDataConfiguration());
            modelBuilder.ApplyConfiguration(new UserDataConfiguration());
            modelBuilder.ApplyConfiguration(new StudentDataConfiguration());

            var user1 = new User { Id = 1, Email = "A@A.A", FirstName = "A_first", LastName = "A_second", NickName = "A_nick" };
            var user2 = new User { Id = 2, Email = "B@B.B", FirstName = "B_first", LastName = "B_second", NickName = "B_nick" };
            var user3 = new User { Id = 3, Email = "C@C.C", FirstName = "C_first", LastName = "C_second", NickName = "C_nick" };
            var user4 = new User { Id = 4, Email = "D@D.D", FirstName = "D_first", LastName = "D_second", NickName = "D_nick" };
            var user5 = new User { Id = 5, Email = "E@E.E", FirstName = "E_first", LastName = "E_second", NickName = "E_nick" };

            modelBuilder.Entity<User>().HasData(user1, user2, user3, user4, user5);

            var course1 = new Course { Id = 1, CreatedById = user1.Id, CreatedDate = new DateTime(2023, 08, 23).ToUniversalTime(), Description = "The 1st Course Description", Name = "The 1st Course", Level = DifficultyLevel.Junior };
            var course2 = new Course { Id = 2, CreatedById = user1.Id, CreatedDate = new DateTime(2023, 08, 23).ToUniversalTime(), Description = "The 2nd Course Description", Name = "The 2nd Course", Level = DifficultyLevel.Junior };
            var course3 = new Course { Id = 3, CreatedById = user1.Id, CreatedDate = new DateTime(2023, 08, 23).ToUniversalTime(), Description = "The 3th Course Description", Name = "The 3th Course", Level = DifficultyLevel.Middle };
            var course4 = new Course { Id = 4, CreatedById = user1.Id, CreatedDate = new DateTime(2023, 08, 23).ToUniversalTime(), Description = "The 4th Course Description", Name = "The 4th Course", Level = DifficultyLevel.Middle };
            var course5 = new Course { Id = 5, CreatedById = user1.Id, CreatedDate = new DateTime(2023, 08, 23).ToUniversalTime(), Description = "The 5th Course Description", Name = "The 5th Course", Level = DifficultyLevel.Senior };

            modelBuilder.Entity<Course>().HasData(course1, course2, course3, course4, course5);
            modelBuilder.Entity<Lesson>().HasData(
                new Lesson { Id = 1, CourseId = course1.Id, Description = "The First Lesson Descriprion", Name = "The First Lesson" },
                new Lesson { Id = 2, CourseId = course2.Id, Description = "The First Lesson Descriprion", Name = "The First Lesson" },
                new Lesson { Id = 3, CourseId = course3.Id, Description = "The First Lesson Descriprion", Name = "The First Lesson" },
                new Lesson { Id = 4, CourseId = course4.Id, Description = "The First Lesson Descriprion", Name = "The First Lesson" },
                new Lesson { Id = 5, CourseId = course5.Id, Description = "The First Lesson Descriprion", Name = "The First Lesson" });

            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, UserId = user2.Id });
        }
    }
}