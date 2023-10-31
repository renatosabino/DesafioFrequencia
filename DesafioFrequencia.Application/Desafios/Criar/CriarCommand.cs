using MediatR;

namespace DesafioFrequencia.Application.Desafios.Criar;

public sealed record CriarCommand(string Nome, DateTime Inicio, DateTime Fim, DayOfWeek InicioDaSemana, int QuantidadeDiasObrigatorio) : IRequest;