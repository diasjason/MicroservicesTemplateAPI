using FluentValidation;

namespace MicroservicesTemplateAPI.Application.Contact.Queries
{
    public class GetContactByEmailValidator : AbstractValidator<GetContactByEmailQuery>
    {
        public GetContactByEmailValidator()
        {
            RuleFor(x => x.Email).NotEmpty();
        }
    }
}
