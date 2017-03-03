using FluentValidation;
using IFBusTicketSystem.Foundation.RequestEntities;

namespace IFBusTicketSystem.BL.Validators
{
    class UserBaseQueryValidator : AbstractValidator<UserBaseQuery>
    {
        public UserBaseQueryValidator()
        {
            //RuleFor(query => query.User).NotNull().WithMessage("User is required");
            //RuleFor(query => query.User.Email).EmailAddress().WithMessage("Email is required");
            //RuleFor(query => query.User.Password).Length(8, 100).WithMessage("Password must be at least 8 characters long");
            //RuleFor(query => query.User.FirstName).Length(1, 20).WithMessage("Invalid Name");
            //RuleFor(query => query.User.LastName).Length(1, 20).WithMessage("Invalid Surname");
        }
    }
}
