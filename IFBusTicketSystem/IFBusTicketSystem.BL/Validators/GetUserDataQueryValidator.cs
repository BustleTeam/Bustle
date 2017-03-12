using FluentValidation;
using IFBusTicketSystem.Foundation.RequestEntities;

namespace IFBusTicketSystem.BL.Validators
{
    public class GetUserDataQueryValidator : AbstractValidator<GetUserDataQuery>
    {
        public GetUserDataQueryValidator()
        {
            RuleFor(_ => _).NotNull();
            RuleFor(_ => _.UserId).NotNull().NotEmpty();
        }
    }
}
