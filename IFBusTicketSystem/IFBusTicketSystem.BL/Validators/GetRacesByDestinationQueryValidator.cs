using FluentValidation;
using IFBusTicketSystem.Foundation.RequestEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFBusTicketSystem.BL.Validators
{
    class GetRacesByDestinationQueryValidator : AbstractValidator<GetRacesByDestinationQuery>
    {
        public GetRacesByDestinationQueryValidator()
        {
            RuleFor(query => query.Destination).NotEmpty().WithMessage("Destination is required");
        }
    }
}
