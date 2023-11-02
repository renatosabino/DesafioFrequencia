using MediatR;

namespace DesafioFrequencia.Application.RegistroFrequencias.FaltaJustificada;

public record FaltaJustificadaCommand(int DesafioId, int ParticipanteId, DateTime Data, string Imagem) : IRequest;

