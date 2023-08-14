using FluentValidation;
using com.expenses.domain.DomainModel.User;

namespace com.expenses.domain.Validators.User
{
    public class UserValidator: AbstractValidator<UserModel>
    {
        public UserValidator()
        {
            RuleFor(c => c.Email)
                .EmailAddress();

        }
    }
}
