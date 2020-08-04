using FluentValidation;

namespace MicroservicesTemplateAPI.Application.Student.Commands
{
    public class CreateStudentValidator : AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.StreetAddress).NotEmpty();
            RuleFor(x => x.State).NotEmpty();
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.Phone).NotEmpty().MinimumLength(10);
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Type).NotEmpty();
            RuleFor(x => x.AssignedTo).NotEmpty();

        }
    }
}
