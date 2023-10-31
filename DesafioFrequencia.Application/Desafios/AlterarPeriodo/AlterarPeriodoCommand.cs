using MediatR;

namespace DesafioFrequencia.Application.Desafios.AlterarPeriodo;

public sealed record AlterarPeriodoCommand(int Id, DateTime Inicio, DateTime Fim) : IRequest;
