using MediatR;

namespace DesafioFrequencia.Application.RegistroFrequencias.Falta;

public sealed record FaltaCommand(int DesafioId, int ParticipanteId, DateTime Data) : IRequest;
