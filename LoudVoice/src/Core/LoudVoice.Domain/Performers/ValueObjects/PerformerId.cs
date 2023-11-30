using LoudVoice.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoudVoice.Domain.Performers.ValueObjects
{
    public sealed class PerformerId : ValueObject
    {
        public Guid Value { get; set; }

        public PerformerId(Guid value)
        {
            Value = value;
        }

        public static PerformerId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static implicit operator Guid(PerformerId id)
            => id.Value;

        public static implicit operator PerformerId(Guid id)
            => new(id);

        public override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
