using MediatR;

namespace DesafioFrequencia.Application.Participantes.Editar;

public sealed record EditarCommand(int Id, string Nome, string Sobrenome, string Sexo, DateTime DataDeNascimento) : IRequest;
