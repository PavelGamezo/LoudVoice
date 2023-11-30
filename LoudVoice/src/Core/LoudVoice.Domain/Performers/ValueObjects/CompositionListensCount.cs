using ErrorOr;
using LoudVoice.Domain.Common;

namespace LoudVoice.Domain.Compositions.ValueObjects
{
    public sealed class CompositionListensCount : ValueObject
    {
        public uint Value { get; init; }

        public CompositionListensCount(uint value) 
        {
            Value = value;
        }

        public static ErrorOr<CompositionListensCount> Create(uint value)
            => new CompositionListensCount(value);

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static implicit operator uint(CompositionListensCount value) 
            => value.Value;

        public static implicit operator CompositionListensCount(uint value) 
            => new CompositionListensCount(value);
    }
}
