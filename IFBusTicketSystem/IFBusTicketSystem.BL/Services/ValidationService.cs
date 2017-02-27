using FluentValidation;
using IFBusTicketSystem.BL.Interfaces;
using IFBusTicketSystem.Foundation.RequestEntities;

namespace IFBusTicketSystem.BL.Services
{
    public class ValidationService : IValidationService
    {
        public void Validate<T, TV>(T entity, TV validator)
            where T: EntityBaseQuery
            where TV: AbstractValidator<T>
        {
            validator.ValidateAndThrow(entity);          
        }
    }
}
