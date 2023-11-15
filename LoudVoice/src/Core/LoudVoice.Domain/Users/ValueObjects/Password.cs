using ErrorOr;
using FluentResults;
using LoudVoice.Domain.Common;
using LoudVoice.Domain.Users.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoudVoice.Domain.Users.ValueObjects
{
    public sealed class Password : ValueObject
    {
        public string Value { get; init; }

        private Password(string value)
        {
            Value = value;
        }

        public static ErrorOr<Password> Create(string password) 
        {
            if (string.IsNullOrEmpty(password))
            {
                return DomainErrors.EmptyPassword;
            }

            return new Password(password);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static implicit operator Password(string value) => 
            new (value);

        public static implicit operator string(Password password) 
            => password.Value;
    }
}
