using FluentValidation;
using IFBusTicketSystem.Foundation.RequestEntities;

namespace IFBusTicketSystem.BL.Validators
{
    class RouteBaseQueryValidator : AbstractValidator<RouteBaseQuery>
    {
        public RouteBaseQueryValidator()
        {
            RuleFor(query => query.Route).NotNull().WithMessage("Route is required");
            RuleFor(query => query.Route.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(query => query.Route.Stations).SetCollectionValidator(new StationsValidator());
        }
    }
}
