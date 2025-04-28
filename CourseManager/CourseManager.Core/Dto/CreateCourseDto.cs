using CourseManager.Core.Entities;

namespace CourseManager.Core.Dto;

public class CreateCourseDto
{
    public string Title; 
    public string Platform;
    public DateTime FinishDate;
    public CourseStateEnum State;
}
