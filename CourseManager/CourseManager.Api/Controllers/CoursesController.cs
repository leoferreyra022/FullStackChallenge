using CourseManager.Core.Dto;
using CourseManager.Business.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CursosController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CursosController(ICourseService cursoService)
    {
        _courseService = cursoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CourseDto>>> GetAll()
    {
        var cursos = await _courseService.GetAllAsync();
        return Ok(cursos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CourseDto>> GetById(int id)
    {
        var curso = await _courseService.GetByIdAsync(id);
        if (curso == null)
            return NotFound();
        return Ok(curso);
    }

    [HttpPost]
    public async Task<ActionResult<CourseDto>> Create([FromBody] CreateCourseDto cursoDto)
    {
        var createdCurso = await _courseService.CreateAsync(cursoDto);
        return CreatedAtAction(nameof(GetById), new { id = createdCurso.Id }, createdCurso);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCourseDto cursoDto)
    {
        if (id != cursoDto.Id)
            return BadRequest();

        await _courseService.UpdateAsync(id, cursoDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _courseService.DeleteAsync(id);
        return NoContent();
    }

    //[HttpGet("plataforma/{plataforma}")]
    //public async Task<ActionResult<IEnumerable<CourseDto>>> GetByPlataforma(string plataforma)
    //{
    //    var cursos = await _courseService.GetByPlatformAsync(plataforma);
    //    return Ok(cursos);
    //}

    //[HttpGet("search")]
    //public async Task<ActionResult<IEnumerable<CourseDto>>> Search([FromQuery] string term)
    //{
    //    var cursos = await _courseService.SearchByQueryAsync(term);
    //    return Ok(cursos);
    //}
}