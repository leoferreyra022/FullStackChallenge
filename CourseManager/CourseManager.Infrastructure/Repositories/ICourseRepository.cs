using CourseManager.Core.Entities;

namespace CourseManager.Infrastructure.Repositories;

public interface ICourseRepository : IRepository<Course>
{
    Task<IEnumerable<Course>> GetByStateAsync(CourseStateEnum state);
}
