using FluentValidation;
using IFBusTicketSystem.Foundation.Types.Entities;
using System;

namespace IFBusTicketSystem.BL.Validators
{
    class StopsValidator : AbstractValidator<Stop>
    {
        public StopsValidator()
        {
            RuleFor(stop => stop.Station).NotNull().WithMessage("Station is required");
            RuleFor(stop => stop.Station.Name).NotEmpty().WithMessage("Station Name is required");
            RuleFor(stop => stop.Departure).GreaterThan(DateTime.Now).WithMessage("Departure time is invalid");
            RuleFor(stop => stop.Arrival).GreaterThan(DateTime.Now).WithMessage("Arrival time is invalid");
        }
    }
}
