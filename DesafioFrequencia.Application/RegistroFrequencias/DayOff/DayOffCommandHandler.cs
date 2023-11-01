using DesafioFrequencia.Domain.Interfaces;
using DesafioFrequencia.Domain.Models.RegistroFrequencias;
using DesafioFrequencia.Domain.Models.RegistroFrequencias.ValueObjects;
using MediatR;

namespace DesafioFrequencia.Application.RegistroFrequencias.DayOff
{
    public class DayOffCommandHandler : IRequestHandler<DayOffCommand>
    {

        private readonly IUnitOfWork _unitOfWork;

        public DayOffCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DayOffCommand request, CancellationToken cancellationToken)
        {
            var desafio = await _unitOfWork.DesafioRepository.GetByIdAsync(request.DesafioId, cancellationToken);
            if (desafio == null)
                throw new ArgumentException("Não foi encontrado nenhum desafio com este Id.", nameof(request.DesafioId));

            var participante = await _unitOfWork.ParticipanteRepository.GetByIdAsync(request.ParticipanteId, cancellationToken);
            if (participante == null)
                throw new ArgumentException("Não foi encontrado nenhum participante com este Id.", nameof(request.DesafioId));

            var registroFrequencia = new RegistroFrequencia(new DataFrequencia(request.Data), desafio, participante);

            registroFrequencia.DayOff();

            await _unitOfWork.RegistroFrequenciaRepository.CreateAsync(registroFrequencia, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
