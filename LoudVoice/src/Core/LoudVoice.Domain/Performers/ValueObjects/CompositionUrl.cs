using ErrorOr;
using LoudVoice.Domain.Common;
using LoudVoice.Domain.Performers.Errors;

namespace LoudVoice.Domain.Compositions.ValueObjects
{
    public sealed class CompositionUrl : ValueObject
    {
        public string Value { get; init; }

        public CompositionUrl(string value)
        {
            Value = value;
        }

        public static ErrorOr<CompositionUrl> Create(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return CompositionsDomainErrors.EmptyUrl;
            }

            return new CompositionUrl(email);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static implicit operator CompositionUrl(string url) =>
            new(url);

        public static implicit operator string(CompositionUrl url) =>
            url.Value;
    }
}
