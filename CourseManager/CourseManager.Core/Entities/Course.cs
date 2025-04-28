namespace CourseManager.Core.Entities;

public class Course
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Platform { get; set; }
    public CourseStateEnum State { get; set; }
    public DateTime FinishDate { get; set; }
}

public enum CourseStateEnum
{
    Initiated,
    InProgress,
    Paused,
    Finished
}
