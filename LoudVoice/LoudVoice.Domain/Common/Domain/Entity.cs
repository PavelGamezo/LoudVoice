namespace LoudVoice.Domain.Common.Domain
{
    public abstract class Entity : IEquatable<Entity>
    {
        public Guid Id { get; init; }

        public IEnumerable<IDomainEvent> Events => _domainEvents;

        private readonly List<IDomainEvent> _domainEvents = new();

        protected Entity(Guid id)
        {
            Id = id;
        }

        public void AddDomainEvent(IDomainEvent domainEvent) => 
            _domainEvents.Add(domainEvent);
        
        public void RemoveDomainEvent(IDomainEvent domainEvent) =>
            _domainEvents.Remove(domainEvent);

        public void Clear() => _domainEvents.Clear();

        public override bool Equals(object? obj)
        {
            if (obj is null || obj.GetType() != GetType() || obj is not Entity entity)
            {
                return false;
            }

            return entity.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public bool Equals(Entity? other)
        {
            if (other is null || other.GetType() != GetType())
            {
                return false;
            }

            return other.Id == Id;
        }

        public static bool operator ==(Entity? first, Entity? second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(Entity? first, Entity? second)
        {
            return !(first == second);
        }
    }
}
