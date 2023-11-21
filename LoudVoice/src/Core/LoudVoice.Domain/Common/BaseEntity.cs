using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoudVoice.Domain.Common
{
    public class BaseEntity<TId> : IEquatable<BaseEntity<TId>>
        where TId : notnull
    {
        public TId Id { get; protected set; }
        public IEnumerable<IDomainEvent> Events => _domainEvents;

        protected BaseEntity(TId id)
        {
            Id = id;
        }

        private readonly List<IDomainEvent> _domainEvents = new();

        public void AddDomainEvent(IDomainEvent domainEvent) => 
            _domainEvents.Add(domainEvent);

        public void RemoveDomainEvent(IDomainEvent domainEvent) => 
            _domainEvents.Remove(domainEvent);

        public void ClearDomainEvents() => _domainEvents.Clear();

        public override bool Equals(object? obj)
        {
            if (obj is null || obj.GetType() != GetType() || obj is not BaseEntity<TId> entity)
            {
                return false;
            }

            return Id.Equals(entity.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public bool Equals(BaseEntity<TId>? other)
        {
            if (other is null || other.GetType() != GetType())
            {
                return false;
            }

            return Id.Equals(other.Id);
        }

        public static bool operator ==(BaseEntity<TId>? first, BaseEntity<TId>? second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(BaseEntity<TId>? first, BaseEntity<TId>? second)
        {
            return !(first == second);
        }
    }
}
