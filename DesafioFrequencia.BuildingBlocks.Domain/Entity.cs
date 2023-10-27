using DesafioFrequencia.BuildingBlocks.Domain;

namespace DesafioFrequencia.Domain.Models
{
    public abstract class Entity
    {
        private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
        public virtual int Id { get; protected set; }

        protected void RaiseDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
}
