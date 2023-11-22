using LoudVoice.Domain.Common;
using LoudVoice.Domain.Compositions.ValueObjects;
using LoudVoice.Domain.Performers.Entity;

namespace LoudVoice.Domain.Compositions.Entity
{
    public sealed class Composition : AggregateRoot<Guid>
    {
        public Name Name { get; set; }
        public ListensCount ListensCount { get; set; }
        public CompositionUrl Url { get; set; }

        public Performer Performer { get; set; }
        public Guid PerformerId { get; set; }

        private Composition(Guid id) : base(id) { }

        internal Composition(Guid id, string name, uint listensCount, string url) : base(id)
        {
            Name = name;
            ListensCount = listensCount;
            Url = url;
        }
    }
}
