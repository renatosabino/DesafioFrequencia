using DesafioFrequencia.BuildingBlocks.Domain;

namespace DesafioFrequencia.Domain.DomainEvents
{
    public sealed record DayOffDomainEvent(int IdDesafio, int IdParticipante): IDomainEvent;
}
