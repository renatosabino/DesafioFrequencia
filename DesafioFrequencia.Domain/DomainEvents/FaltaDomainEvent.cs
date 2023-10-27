using DesafioFrequencia.BuildingBlocks.Domain;

namespace DesafioFrequencia.Domain.DomainEvents
{
    public sealed record FaltaDomainEvent(int IdDesafio, int IdParticipante) : IDomainEvent;
}
