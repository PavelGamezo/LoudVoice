using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoudVoice.Domain.Users.Errors
{
    public static class DomainErrors
    {
        public static readonly Error EmptyEmail = Error.NotFound(
            code: "DomainError.EmptyEmail",
            description: "Email is required and can't be empty");

        public static readonly Error EmptyLogin = Error.NotFound(
            code: "DomainError.EmptyLogin",
            description: "Login is required and can't be empty");
        
        public static readonly Error EmptyPassword = Error.NotFound(
            code: "DomainError.EmptyPassword",
            description: "Password is required and can't be empty");
    }
}
