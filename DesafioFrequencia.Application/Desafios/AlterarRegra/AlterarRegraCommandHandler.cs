using DesafioFrequencia.Domain.Interfaces;
using DesafioFrequencia.Domain.Models.Desafios.ValueObjects;
using MediatR;

namespace DesafioFrequencia.Application.Desafios.AlterarRegra
{
    public class AlterarPeriodoCommandHandler : IRequestHandler<AlterarRegraCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AlterarPeriodoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(AlterarRegraCommand request, CancellationToken cancellationToken)
        {
            var desafio = await _unitOfWork.DesafioRepository.GetByIdAsync(request.Id, cancellationToken);

            if (desafio is null)
                throw new ArgumentException("Não foi encontrado nenhum desafio com este Id.", nameof(request.Id));

            desafio.AlterarRegra(new Regra(request.InicioDaSemana, request.QuantidadeDiasObrigatorio));

            _unitOfWork.DesafioRepository.Update(desafio);

            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
