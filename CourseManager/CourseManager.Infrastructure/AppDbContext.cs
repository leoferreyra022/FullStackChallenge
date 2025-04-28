using CourseManager.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseManager.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Course> Courses => Set<Course>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>()
            .HasKey(u => u.Id);

        modelBuilder.Entity<Course>()
            .Property(c => c.Title)
            .HasMaxLength(200)
            .IsRequired();

        modelBuilder.Entity<Course>().HasData(
            new Course { Id = 1, Title = "Introduction to C#", Platform = "Udemy", State = CourseStateEnum.Initiated, FinishDate = new DateTime(2025, 1, 1) },
            new Course { Id = 2, Title = "Advanced .NET Development", Platform = "Pluralsight", State = CourseStateEnum.Initiated, FinishDate = new DateTime(2025, 2, 15) },
            new Course { Id = 3, Title = "Entity Framework Core Mastery", Platform = "LinkedIn Learning", State = CourseStateEnum.Paused, FinishDate = new DateTime(2025, 3, 10) },
            new Course { Id = 4, Title = "Mastering ASP.NET Core", Platform = "Coursera", State = CourseStateEnum.Initiated, FinishDate = new DateTime(2025, 4, 5) },
            new Course { Id = 5, Title = "C# Design Patterns", Platform = "Udemy", State = CourseStateEnum.Initiated, FinishDate = new DateTime(2025, 5, 20) },
            new Course { Id = 6, Title = "Clean Code Principles", Platform = "Pluralsight", State = CourseStateEnum.Paused, FinishDate = new DateTime(2025, 6, 15) },
            new Course { Id = 7, Title = "Microservices with .NET", Platform = "LinkedIn Learning", State = CourseStateEnum.Initiated, FinishDate = new DateTime(2025, 7, 10) },
            new Course { Id = 8, Title = "Blazor WebAssembly Fundamentals", Platform = "Udemy", State = CourseStateEnum.Initiated, FinishDate = new DateTime(2025, 8, 25) },
            new Course { Id = 9, Title = "Testing in .NET", Platform = "Pluralsight", State = CourseStateEnum.Paused, FinishDate = new DateTime(2025, 9, 5) },
            new Course { Id = 10, Title = "Azure for .NET Developers", Platform = "Coursera", State = CourseStateEnum.Initiated, FinishDate = new DateTime(2025, 10, 15) },
            new Course { Id = 11, Title = "Dependency Injection in .NET", Platform = "LinkedIn Learning", State = CourseStateEnum.Initiated, FinishDate = new DateTime(2025, 11, 1) },
            new Course { Id = 12, Title = "LINQ Mastery", Platform = "Udemy", State = CourseStateEnum.Initiated, FinishDate = new DateTime(2025, 12, 10) }
        );
    }
}
