using AutoMapper;
using CourseManager.Core.Dto;
using CourseManager.Core.Entities;
using CourseManager.Infrastructure;
using CourseManager.Infrastructure.Repositories;

namespace CourseManager.Business.Services;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _repo;
    private readonly IMapper _mapper;
    private readonly AppDbContext _context;

    public CourseService(
        ICourseRepository repo,
        IMapper mapper,
        AppDbContext context)
    {
        _repo = repo;
        _mapper = mapper;
        _context = context;
    }

    public async Task<IEnumerable<CourseDto>> GetAllAsync()
    {
        var entities = await _repo.GetAllAsync();
        return _mapper.Map<IEnumerable<CourseDto>>(entities);
    }

    public async Task<CourseDto> GetByIdAsync(int id)
    {
        var entity = await _repo.GetByIdAsync(id);
        if (entity == null)
        {
            throw new Exception($"Curso con Id={id} no existe.");
        }

        return _mapper.Map<CourseDto>(entity);
    }

    public async Task<CourseDto> CreateAsync(CreateCourseDto dto)
    {
        var entity = _mapper.Map<Course>(dto);
        await _repo.AddAsync(entity);
        await _context.SaveChangesAsync();
        return _mapper.Map<CourseDto>(entity);
    }

    public async Task<CourseDto> UpdateAsync(int id, UpdateCourseDto dto)
    {
        var entity = await _repo.GetByIdAsync(id);
        if (entity == null)
            throw new Exception($"Curso con Id={id} no existe.");

        // Mapea el dto a la entidad a actualizar
        _mapper.Map(dto, entity);

        _repo.Update(entity);
        await _context.SaveChangesAsync();

        return _mapper.Map<CourseDto>(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _repo.GetByIdAsync(id) ?? 
            throw new Exception($"Curso con Id={id} no existe.");

        _repo.Delete(entity);
        await _context.SaveChangesAsync();
    }
}
