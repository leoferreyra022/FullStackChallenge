using CourseManager.Core.Dto;
using FluentValidation;

namespace CourseManager.Business.Validators;

public class CreateCourseDtoValidator : AbstractValidator<CreateCourseDto>
{
    public CreateCourseDtoValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Platform).NotEmpty();
    }
}
