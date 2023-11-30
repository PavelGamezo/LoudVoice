using ErrorOr;
using FluentResults;
using LoudVoice.Domain.Common;
using LoudVoice.Domain.Users.Errors;

namespace LoudVoice.Domain.Users.ValueObjects
{
    public sealed class Login : ValueObject
    {
        public string Value { get; init; }

        private Login(string value)
        {
            Value = value;
        }

        public static ErrorOr<Login> Create(string login)
        {
            if (string.IsNullOrEmpty(login))
            {
                return UserDomainErrors.EmptyLogin;
            }

            return new Login(login);
        }

        public override string ToString()
        {
            return Value;
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static implicit operator Login(string login) =>
            new Login(login);

        public static implicit operator string(Login login) => 
            login.Value;
    }
}
