using DesafioFrequencia.Domain.Interfaces;
using DesafioFrequencia.Domain.Models.Desafios.ValueObjects;
using MediatR;

namespace DesafioFrequencia.Application.Desafios.AlterarPeriodo
{
    public class AlterarPeriodoCommandHandler : IRequestHandler<AlterarPeriodoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AlterarPeriodoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(AlterarPeriodoCommand request, CancellationToken cancellationToken)
        {
            var desafio = await _unitOfWork.DesafioRepository.GetByIdAsync(request.Id, cancellationToken);

            if (desafio is null)
                throw new ArgumentException("Não foi encontrado nenhum desafio com este Id.", nameof(request.Id));

            desafio.AlterarPeriodo(new Periodo(request.Inicio, request.Fim));

            _unitOfWork.DesafioRepository.Update(desafio);

            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
