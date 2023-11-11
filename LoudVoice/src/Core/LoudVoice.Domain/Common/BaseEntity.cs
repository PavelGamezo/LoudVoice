using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoudVoice.Domain.Common
{
    public class BaseEntity
    {
        public Guid Id { get; init; }
        public IEnumerable<IDomainEvent> Events => _domainEvents;

        protected BaseEntity(Guid id)
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
            if(obj is null || obj.GetType() != GetType() || obj is not BaseEntity entity)
            {
                return false;
            }

            return entity.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public bool Equals(BaseEntity? other)
        {
            if (other is null || other.GetType() != GetType())
            {
                return false;
            }

            return other.Id == Id;
        }

        public static bool operator ==(BaseEntity? first, BaseEntity? second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(BaseEntity? first, BaseEntity? second)
        {
            return !(first == second);
        }
    }
}
