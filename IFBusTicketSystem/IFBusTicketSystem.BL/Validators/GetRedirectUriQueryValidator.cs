using FluentValidation;
using IFBusTicketSystem.Foundation.RequestEntities;

namespace IFBusTicketSystem.BL.Validators
{
    public class GetRedirectUriQueryValidator : AbstractValidator<GetRedirectUriQuery>
    {
        public GetRedirectUriQueryValidator()
        {
            RuleFor(query => query.QueryStrings).NotNull().NotEmpty();
            RuleFor(query => query.Identity).NotNull();
            RuleFor(query => query.Provider).NotNull().NotEmpty();
        }
    }
}
