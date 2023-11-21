using ErrorOr;
using LoudVoice.Domain.Common;
using LoudVoice.Domain.Compositions.Errors;

namespace LoudVoice.Domain.Compositions.ValueObjects
{
    public class Name : ValueObject
    {
        private string Value { get; set; }

        public Name(string value)
        {
            Value = value;
        }

        public static ErrorOr<Name> Create(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return CompositionsDomainErrors.EmptyName;
            }
            return new Name(name);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString()
        {
            return Value;
        }

        public static implicit operator string(Name name)
            => name.ToString();

        public static implicit operator Name(string name)
            => new(name);
    }
}
