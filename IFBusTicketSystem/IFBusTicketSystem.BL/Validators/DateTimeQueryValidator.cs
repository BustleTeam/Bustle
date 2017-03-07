using FluentValidation;
using IFBusTicketSystem.Foundation.RequestEntities;
using System;

namespace IFBusTicketSystem.BL.Validators
{
    class DateTimeQueryValidator : AbstractValidator<DateTimeQuery>
    {
        public DateTimeQueryValidator()
        {
            RuleFor(query => query.Date).GreaterThanOrEqualTo(DateTime.Now).WithMessage("Date is invalid");
        }
    }
}
