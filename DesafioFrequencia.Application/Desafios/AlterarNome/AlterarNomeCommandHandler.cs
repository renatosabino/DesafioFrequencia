using DesafioFrequencia.Domain.Interfaces;
using MediatR;

namespace DesafioFrequencia.Application.Desafios.AlterarNome
{
    public class AlterarPeriodoCommandHandler : IRequestHandler<AlterarNomeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AlterarPeriodoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(AlterarNomeCommand request, CancellationToken cancellationToken)
        {
            var desafio = await _unitOfWork.DesafioRepository.GetByIdAsync(request.Id, cancellationToken);

            if (desafio is null)
                throw new ArgumentException("Não foi encontrado nenhum desafio com este Id.", nameof(request.Id));

            desafio.AlterarNome(request.Nome);

            _unitOfWork.DesafioRepository.Update(desafio);

            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
