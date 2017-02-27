using FluentValidation;
using IFBusTicketSystem.Foundation.Types.Entities;

namespace IFBusTicketSystem.BL.Validators
{
    class SeatsValidator : AbstractValidator<Seat>
    {
        public SeatsValidator()
        {
            RuleFor(seat => seat.Number).ExclusiveBetween(0, 200).WithMessage("Seat Number is invalid");
        }
    }
}
