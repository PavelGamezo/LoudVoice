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
    public sealed class Email : ValueObject
    {
        public string Value { get; init; }

        public Email(string value)
        {
            Value = value;
        }

        public static Result<Email> Create(string email)
        {
            if (string.IsNullOrEmpty(email)) 
            {
                return Result.Fail<Email>(new EmptyEmailError());
            }

            return new Email(email);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static implicit operator Email(string value) =>
            new(value);

        public static implicit operator string(Email email) => 
            email.Value;
    }
}
