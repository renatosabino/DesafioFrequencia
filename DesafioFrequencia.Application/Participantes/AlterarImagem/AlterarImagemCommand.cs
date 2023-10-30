using MediatR;

namespace DesafioFrequencia.Application.Participantes.AlterarImagem;

public sealed record AlterarImagemCommand(int ParticipanteId, string Imagem) : IRequest;