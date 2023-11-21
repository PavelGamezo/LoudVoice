using ErrorOr;
using LoudVoice.Domain.Common;
using LoudVoice.Domain.Compositions.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoudVoice.Domain.Compositions.ValueObjects
{
    public sealed class CompositionUrl : ValueObject
    {
        private string Value { get; init; }

        private CompositionUrl(string value)
        {
            Value = value;
        }

        public ErrorOr<CompositionUrl> Create(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return CompositionsDomainErrors.EmptyUrl;
            }

            return new CompositionUrl(url);
        }

        public override string ToString()
            => Value;

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static implicit operator CompositionUrl(string value) 
            => new(value);

        public static implicit operator string(CompositionUrl value)
        {
            return value.ToString();
        }
    }
}
