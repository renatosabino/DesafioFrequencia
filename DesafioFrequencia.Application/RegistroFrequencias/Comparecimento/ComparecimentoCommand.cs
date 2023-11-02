using MediatR;

namespace DesafioFrequencia.Application.RegistroFrequencias.Comparecimento;

public record ComparecimentoCommand(int DesafioId, int ParticipanteId, DateTime Data, string Imagem, string Modalidade) : IRequest;
