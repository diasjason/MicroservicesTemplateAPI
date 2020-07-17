using FluentValidation;

namespace Tandem.Application.User.Queries
{
    public class GetUserByEmailValidator : AbstractValidator<GetUserByEmailQuery>
    {
        public GetUserByEmailValidator()
        {
            RuleFor(x => x.Email).NotEmpty(); //.EmailAddress();
        }
    }
}
