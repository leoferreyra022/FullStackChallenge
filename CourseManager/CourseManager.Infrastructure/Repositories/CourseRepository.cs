using CourseManager.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseManager.Infrastructure.Repositories;

public class CourseRepository : Repository<Course>, ICourseRepository
{
    public CourseRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Course>> GetByStateAsync(CourseStateEnum state)
    {
        return await context.Set<Course>().Where(c => c.State == state).ToListAsync();
    }
}
