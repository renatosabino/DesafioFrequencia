using DesafioFrequencia.BuildingBlocks.Domain;

namespace DesafioFrequencia.Domain.DomainEvents
{
    public sealed record ComparecimentoDomainEvent(int IdDesafio, int IdParticipante): IDomainEvent;
}
