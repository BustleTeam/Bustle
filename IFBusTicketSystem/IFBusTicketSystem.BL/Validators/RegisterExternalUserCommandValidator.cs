using FluentValidation;
using IFBusTicketSystem.Foundation.RequestEntities;

namespace IFBusTicketSystem.BL.Validators
{
    public class RegisterExternalUserCommandValidator : AbstractValidator<RegisterExternalUserCommand>
    {
        public RegisterExternalUserCommandValidator()
        {
            RuleFor(_ => _.UserName).NotNull().NotEmpty();
            RuleFor(_ => _.AccessToken).NotNull().NotEmpty();
            RuleFor(_ => _.Provider).NotNull().NotEmpty();
        }
    }
}
