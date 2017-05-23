using FluentValidation;
using IFBusTicketSystem.Foundation.RequestEntities;

namespace IFBusTicketSystem.BL.Validators
{
    public class ObtainLocalAccessTokenCommandValidator : AbstractValidator<ObtainLocalAccessTokenCommand>
    {
        public ObtainLocalAccessTokenCommandValidator()
        {
            RuleFor(_ => _.Provider).NotNull().NotEmpty();
            RuleFor(_ => _.ExternalAccessToken).NotNull().NotEmpty();
        }
    }
}
