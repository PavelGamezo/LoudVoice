using LoudVoice.Domain.Common;
using LoudVoice.Domain.Compositions.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoudVoice.Domain.Users.ValueObjects
{
    public sealed class UserId : ValueObject
    {
        public Guid Value { get; set; }

        public UserId(Guid value)
        {
            Value = value;
        }

        public static implicit operator Guid(UserId id) 
            => id.Value;

        public static implicit operator UserId(Guid id)
            => new(id);

        public static UserId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
