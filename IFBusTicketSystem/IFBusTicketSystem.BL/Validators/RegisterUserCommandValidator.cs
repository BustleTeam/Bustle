using FluentValidation;
using IFBusTicketSystem.Foundation.RequestEntities;

namespace IFBusTicketSystem.BL.Validators
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(_ => _.Login).NotEmpty().WithMessage("Login is required.");
            RuleFor(_ => _.Password).NotEmpty().WithMessage("Password is required");
        }
    }
}
