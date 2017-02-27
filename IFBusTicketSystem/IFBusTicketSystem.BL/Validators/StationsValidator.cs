using FluentValidation;
using IFBusTicketSystem.Foundation.Types.Entities;
using System;

namespace IFBusTicketSystem.BL.Validators
{
    class StationsValidator : AbstractValidator<Station>
    {
        public StationsValidator()
        {
            RuleFor(station => station.Name).NotEmpty().WithMessage("Name is required");
        }
    }
}
