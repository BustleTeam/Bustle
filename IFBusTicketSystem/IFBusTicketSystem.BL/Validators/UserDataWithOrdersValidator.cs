using FluentValidation;
using IFBusTicketSystem.Foundation.Types;

namespace IFBusTicketSystem.BL.Validators
{
    public class UserDataWithOrdersValidator : AbstractValidator<UserDataWithOrders>
    {
        public UserDataWithOrdersValidator()
        {
            RuleFor(_ => _).NotNull();
            RuleFor(_ => _.UserName).NotNull().NotEmpty();
            //RuleFor(_ => _.Orders).NotNull();
            RuleFor(_ => (int) _.Sex).NotNull();
        }
    }
}
