using FluentValidation;
using IFBusTicketSystem.Foundation.RequestEntities;
using System;

namespace IFBusTicketSystem.BL.Validators
{
    class GetRacesByDateQueryValidator : AbstractValidator<GetRacesByDateQuery>
    {
        public GetRacesByDateQueryValidator()
        {
            RuleFor(query => query.Date).GreaterThanOrEqualTo(DateTime.Now).WithMessage("Date is invalid");
        }
    }
}
