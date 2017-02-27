using FluentValidation;
using IFBusTicketSystem.Foundation.RequestEntities;

namespace IFBusTicketSystem.BL.Interfaces
{
    public interface IValidationService
    {
        void Validate<T, TV>(T entity, TV validator)
            where T : EntityBaseQuery
            where TV : AbstractValidator<T>;
    }
}
