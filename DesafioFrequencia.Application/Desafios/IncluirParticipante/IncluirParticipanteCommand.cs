using MediatR;

namespace DesafioFrequencia.Application.Desafios.IncluirParticipante;

public sealed record IncluirParticipanteCommand(int DesafioId, int ParticipanteId) : IRequest;