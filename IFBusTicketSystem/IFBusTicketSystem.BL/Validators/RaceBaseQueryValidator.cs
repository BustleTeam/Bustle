using FluentValidation;
using IFBusTicketSystem.Foundation.RequestEntities;

namespace IFBusTicketSystem.BL.Validators
{
    class RaceBaseQueryValidator : AbstractValidator<RaceBaseQuery>
    {
        public RaceBaseQueryValidator()
        {
            RuleFor(query => query.Race).NotNull().WithMessage("Race is required");
            RuleFor(query => query.Race.Route).NotNull().WithMessage("Route is required");
            RuleFor(query => query.Race.Route.Name).NotEmpty().WithMessage("Route name is required");
            RuleFor(query => query.Race.Seats).SetCollectionValidator(new SeatsValidator());
            RuleFor(query => query.Race.Stops).SetCollectionValidator(new StopsValidator());
        }
    }
}
