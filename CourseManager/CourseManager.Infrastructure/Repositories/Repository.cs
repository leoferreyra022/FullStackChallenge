using Microsoft.EntityFrameworkCore;

namespace CourseManager.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly AppDbContext context;
    public Repository(AppDbContext ctx) => context = ctx;

    public async Task<T?> GetByIdAsync(int id) => await context.Set<T>().FindAsync(id);
    public async Task<IEnumerable<T>> GetAllAsync() => await context.Set<T>().ToListAsync();
    public async Task AddAsync(T entity) => await context.Set<T>().AddAsync(entity);
    public void Update(T entity) => context.Set<T>().Update(entity);
    public void Delete(T entity) => context.Set<T>().Remove(entity);
}
