using FluentValidation;
using IFBusTicketSystem.Foundation.RequestEntities;
using System;

namespace IFBusTicketSystem.BL.Validators
{
    class BookTicketQueryValidator : AbstractValidator<BookTicketQuery>
    {
        public BookTicketQueryValidator()
        {
            RuleFor(query => query.ShortTicket).NotNull().WithMessage("Ticket is required");
            RuleFor(query => query.ShortTicket.PassengerEmail).NotEmpty().WithMessage("Passenger name is required");
            RuleFor(query => query.ShortTicket.SeatId).GreaterThan(0).WithMessage("Seat Id is invalid");
        }
    }
}
