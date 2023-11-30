using ErrorOr;

namespace LoudVoice.Domain.Performers.Factories
{
    public interface IPerformerFactory
    {
        Performer Create(string nickname, string description, Guid userId);
    }
}
