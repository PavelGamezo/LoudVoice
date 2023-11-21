using ErrorOr;
using LoudVoice.Domain.Common;
using LoudVoice.Domain.Performers.Errors;

namespace LoudVoice.Domain.Performers.ValueObjects
{
    public sealed class Nickname : ValueObject
    {
        public string Value { get; set; }

        public static ErrorOr<Nickname> Create(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return PerformersDomainErrors.NoNickname;
            }

            return new Nickname(value);
        }

        public Nickname(string value)
        {
            Value = value;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static implicit operator string(Nickname nickname) 
            => nickname.Value;

        public static implicit operator Nickname(string value)
            => new Nickname(value);
    }
}
