using ErrorOr;
using LoudVoice.Domain.Common;

namespace LoudVoice.Domain.Compositions.ValueObjects
{
    public sealed class ListensCount : ValueObject
    {
        private uint Value { get; init; }

        public ListensCount(uint value) 
        {
            Value = value;
        }

        public static ErrorOr<ListensCount> Create(uint value)
            => new ListensCount(value);

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static implicit operator uint(ListensCount value) 
            => value.Value;

        public static implicit operator ListensCount(uint value) 
            => new ListensCount(value);
    }
}
