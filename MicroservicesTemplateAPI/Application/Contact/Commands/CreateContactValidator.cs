using FluentValidation;

namespace MicroservicesTemplateAPI.Application.Contact.Commands
{
    public class CreateContactValidator : AbstractValidator<CreateContactCommand>
    {
        public CreateContactValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Company).NotEmpty();
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
