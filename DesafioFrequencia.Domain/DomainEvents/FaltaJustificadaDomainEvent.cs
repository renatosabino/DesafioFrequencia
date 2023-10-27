using DesafioFrequencia.BuildingBlocks.Domain;

namespace DesafioFrequencia.Domain.DomainEvents
{
    public sealed record FaltaJustificadaDomainEvent(int IdDesafio, int IdParticipante) : IDomainEvent;
}
