using FluentValidation;
using IFBusTicketSystem.Foundation.RequestEntities;

namespace IFBusTicketSystem.BL.Validators
{
    class EntityBaseQueryValidator : AbstractValidator<EntityBaseQuery>
    {
        public EntityBaseQueryValidator()
        {
            RuleFor(query => query.Id).GreaterThan(0).WithMessage("Invalid Id");
        }
    }
}
