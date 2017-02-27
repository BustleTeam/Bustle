using FluentValidation;
using IFBusTicketSystem.Foundation.RequestEntities;

namespace IFBusTicketSystem.BL.Validators
{
    class TicketBaseQueryValidator : AbstractValidator<TicketBaseQuery>
    {
        public TicketBaseQueryValidator()
        {
            RuleFor(query => query.Ticket).NotNull().WithMessage("Ticket is required");
            RuleFor(query => query.Ticket.Passenger).NotNull().WithMessage("Passenger is required");
            RuleFor(query => query.Ticket.Passenger.Name).Length(1, 20).WithMessage("Invalid Name");
            RuleFor(query => query.Ticket.Passenger.Surname).Length(1, 20).WithMessage("Invalid Surname");
            RuleFor(query => query.Ticket.Seat).NotNull().WithMessage("Seat is required");
            RuleFor(query => query.Ticket.Seat.Number).ExclusiveBetween(0, 200).WithMessage("Invalid Seat Number");
        }
    }
}
