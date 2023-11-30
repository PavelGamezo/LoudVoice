using ErrorOr;
using LoudVoice.Domain.Common;
using LoudVoice.Domain.Performers.Errors;

namespace LoudVoice.Domain.Compositions.ValueObjects
{
    public class CompositionName : ValueObject
    {
        public string Value { get; set; }

        public CompositionName(string value)
        {
            Value = value;
        }

        public static ErrorOr<CompositionName> Create(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return CompositionsDomainErrors.EmptyName;
            }

            return new CompositionName(name);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static implicit operator string(CompositionName name)
            => name.Value;

        public static implicit operator CompositionName(string name)
            => new(name);
    }
}
