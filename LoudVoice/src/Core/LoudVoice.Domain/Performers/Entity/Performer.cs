using LoudVoice.Domain.Common;
using LoudVoice.Domain.Compositions.Entity;
using LoudVoice.Domain.Performers.ValueObjects;

namespace LoudVoice.Domain.Performers.Entity
{
    public sealed class Performer : AggregateRoot<Guid>
    {
        public Nickname Nickname { get; set; }
        public Description Description { get; set; }

        private readonly List<Composition> _compositions = new();
        public IReadOnlyCollection<Composition> Compositions => _compositions;

        public Performer(Guid id, string nickname, string description) 
            : base(id)
        {
            Nickname = nickname;
            Description = description;
        }
    }
}
