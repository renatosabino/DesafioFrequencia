using MediatR;

namespace DesafioFrequencia.Application.RegistroFrequencias.DayOff;

public sealed record DayOffCommand(int DesafioId, int ParticipanteId, DateTime Data) : IRequest;
