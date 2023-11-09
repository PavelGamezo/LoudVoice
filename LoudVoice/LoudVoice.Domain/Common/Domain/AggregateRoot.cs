namespace LoudVoice.Domain.Common.Domain
{
    public abstract class AggregateRoot : Entity
    {
        public AggregateRoot(Guid id) : base(id)
        {
        }
    }
}
