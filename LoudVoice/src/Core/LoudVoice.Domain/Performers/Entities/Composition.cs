using LoudVoice.Domain.Common;
using LoudVoice.Domain.Compositions.ValueObjects;
using LoudVoice.Domain.Performers.ValueObjects;

namespace LoudVoice.Domain.Performers.Entities
{
    public sealed class Composition : AggregateRoot<Guid>
    {
        public CompositionName Name { get; set; }
        public CompositionListensCount ListensCount { get; set; }
        public CompositionUrl Url { get; set; }

        public Performer Performer { get; set; }
        public Guid PerformerId { get; set; }

        private Composition(Guid id) : base(id) { }

        internal Composition(Guid id, CompositionName name, CompositionUrl url, Performer performer) 
            : base(id)
        {
            Name = name;
            ListensCount = 0;
            Url = url;
            Performer = performer;
            PerformerId = Performer.Id;
        }

        public static Composition CreateNew(
            string name,
            string url,
            Performer performer)
        {
            return new(Guid.NewGuid(), name, url, performer);
        }
    }
}
