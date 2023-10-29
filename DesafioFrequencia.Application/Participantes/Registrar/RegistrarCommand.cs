using MediatR;

namespace DesafioFrequencia.Application.Participantes.Registrar;

public sealed record RegistrarCommand(string Nome, string Sobrenome, string Sexo, DateTime DataDeNascimento) : IRequest;
