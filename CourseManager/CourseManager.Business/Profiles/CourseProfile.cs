using AutoMapper;
using CourseManager.Core.Dto;
using CourseManager.Core.Entities;

namespace CourseManager.Business.Profiles;

public class CourseProfile : Profile
{
    public CourseProfile()
    {
        CreateMap<CreateCourseDto, Course>();
        CreateMap<Course, CourseDto>();
    }
}
