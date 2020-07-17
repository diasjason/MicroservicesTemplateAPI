using FluentValidation;

namespace Tandem.Application.User.Commands
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.EmailAddress).EmailAddress();
            RuleFor(x => x.PhoneNumber).NotEmpty().MinimumLength(10);
        }
    }
}
