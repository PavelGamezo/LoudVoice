using FluentValidation;
using LoudVoice.Application.User.Queries.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoudVoice.Application.User.Queries.LoginUser
{
    public class LoginUserQueryValidator : AbstractValidator<LoginUserQuery>
    {
        public LoginUserQueryValidator()
        {
            RuleFor(command => command.Login)
                .NotEmpty().WithMessage("Login is required");

            RuleFor(command => command.Password)
                .NotEmpty().WithMessage("Password is required and can't be empty");
        }
    }
}
