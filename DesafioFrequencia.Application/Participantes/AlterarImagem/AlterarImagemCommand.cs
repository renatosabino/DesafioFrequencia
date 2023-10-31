using MediatR;

namespace DesafioFrequencia.Application.Participantes.AlterarImagem;

public sealed record AlterarImagemCommand(int Id, string Imagem) : IRequest;