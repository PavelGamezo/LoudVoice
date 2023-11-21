using ErrorOr;

namespace LoudVoice.Domain.Performers.Errors
{
    public static class PerformersDomainErrors
    {
        public static readonly Error NoNickname = Error.NotFound(
            code: "DomainErrors.EmptyNickname",
            description: "Nickname is required and can't be empty");
    }
}
