using CourseManager.Core.Entities;

namespace CourseManager.Core.Dto;

public class CourseDto 
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Platform { get; set; }
    public DateTime FinishDate { get; set; }
    public CourseStateEnum State { get; set; }

}
