using MediatR;

namespace DesafioFrequencia.Application.Desafios.AlterarNome;

public sealed record AlterarNomeCommand(int Id, string Nome) : IRequest;
