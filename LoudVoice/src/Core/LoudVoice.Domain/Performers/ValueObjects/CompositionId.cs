using LoudVoice.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoudVoice.Domain.Compositions.ValueObjects
{
    public sealed class CompositionId : ValueObject
    {
        public Guid Value { get; set; }

        public CompositionId(Guid value)
        {
            Value = value;
        }

        public static CompositionId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static implicit operator Guid(CompositionId id)
            => id.Value;

        public static implicit operator CompositionId(Guid id)
            => new(id);

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
