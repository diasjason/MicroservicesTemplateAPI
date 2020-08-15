using FluentValidation;

namespace MicroservicesTemplateAPI.Application.Student.Queries
{
    public class GetStudentByEmailValidator : AbstractValidator<GetStudentByEmailQuery>
    {
        public GetStudentByEmailValidator()
        {
            RuleFor(x => x.Email).NotEmpty();
        }
    }
}
