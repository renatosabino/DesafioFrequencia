using MediatR;

namespace DesafioFrequencia.Application.Desafios.AlterarRegra;

public sealed record AlterarRegraCommand(int Id, DayOfWeek InicioDaSemana, int QuantidadeDiasObrigatorio) : IRequest;
