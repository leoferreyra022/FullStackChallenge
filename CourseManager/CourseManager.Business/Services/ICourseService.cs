using CourseManager.Core.Dto;

namespace CourseManager.Business.Services;

public interface ICourseService
{
    Task<IEnumerable<CourseDto>> GetAllAsync();
    Task<CourseDto> GetByIdAsync(int id);
    Task<CourseDto> CreateAsync(CreateCourseDto dto);
    Task<CourseDto> UpdateAsync(int id, UpdateCourseDto dto);
    Task DeleteAsync(int id);
}
