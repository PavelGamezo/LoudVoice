using ErrorOr;
using LoudVoice.Domain.Common;

namespace LoudVoice.Domain.Performers.ValueObjects
{
    public sealed class Description : ValueObject
    {
        private string Value { get; init; }

        public Description(string value)
        {
            Value = value;
        }

        public static ErrorOr<Description> Create(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return new Description("Empty description");
            }

            return new Description(value);
        }

        public override string ToString() => Value;

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static implicit operator string(Description description)
        {
            return description.ToString();
        }

        public static implicit operator Description(string value)
        {
            return new Description(value);
        }
    }
}
