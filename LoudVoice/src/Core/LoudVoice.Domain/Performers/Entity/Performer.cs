using LoudVoice.Domain.Common;
using LoudVoice.Domain.Compositions.Entity;
using LoudVoice.Domain.Performers.ValueObjects;
using LoudVoice.Domain.Users.Entity;

namespace LoudVoice.Domain.Performers.Entity
{
    public sealed class Performer : AggregateRoot<Guid>
    {
        public Nickname Nickname { get; set; }
        public Description Description { get; set; }

        public User User { get; set; }
        public Guid UserId { get; set; }

        private readonly List<Composition> _compositions = new();
        public List<Composition> Compositions => _compositions;

        private Performer(Guid id) : base(id) { }

        internal Performer(Guid id, string nickname, string description) 
            : base(id)
        {
            Nickname = nickname;
            Description = description;
        }
    }
}
