using DesafioFrequencia.Domain.Interfaces;
using MediatR;

namespace DesafioFrequencia.Application.Desafios.IncluirParticipante
{
    public class IncluirParticipanteCommandHandler : IRequestHandler<IncluirParticipanteCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public IncluirParticipanteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(IncluirParticipanteCommand request, CancellationToken cancellationToken)
        {
            var desafio = await _unitOfWork.DesafioRepository.GetByIdAsync(request.ParticipanteId, cancellationToken);

            if (desafio is null)
                throw new ArgumentException("Não foi encontrado nenhum desafio com este Id.", nameof(request.DesafioId));

            var participante = await _unitOfWork.ParticipanteRepository.GetByIdAsync(request.ParticipanteId, cancellationToken);

            if (participante is null)
                throw new ArgumentException("Não foi encontrado nenhum participante com este Id.", nameof(request.ParticipanteId));

            desafio.IncluirParticipante(participante);

            _unitOfWork.DesafioRepository.Update(desafio);

            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
