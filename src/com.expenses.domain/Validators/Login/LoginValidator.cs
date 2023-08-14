using FluentValidation;
using com.expenses.domain.DomainModel.Login;

namespace com.expenses.domain.Validators.Login
{
    public class LoginValidator: AbstractValidator<LoginModel>
    {
        public LoginValidator()
        {
            RuleFor(a => a.Login)
                .NotNull()                
                .NotEmpty()               
                .WithMessage("Login is required");
            RuleFor(a => a.Password)
                .NotNull()
                .NotEmpty()
                .WithMessage("Password is required");
        }
    }
}
