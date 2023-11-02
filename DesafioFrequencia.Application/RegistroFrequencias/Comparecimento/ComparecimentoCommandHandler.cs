using DesafioFrequencia.Domain.Interfaces;
using DesafioFrequencia.Domain.Models.RegistroFrequencias;
using DesafioFrequencia.Domain.Models.RegistroFrequencias.ValueObjects;
using MediatR;

namespace DesafioFrequencia.Application.RegistroFrequencias.Comparecimento
{
    public class ComparecimentoCommandHandler : IRequestHandler<ComparecimentoCommand>
    {
        private IUnitOfWork _unitOfWork;

        public ComparecimentoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(ComparecimentoCommand request, CancellationToken cancellationToken)
        {
            var desafio = await _unitOfWork.DesafioRepository.GetByIdAsync(request.DesafioId, cancellationToken);
            if (desafio == null)
                throw new ArgumentException("Não foi encontrado nenhum desafio com este Id.", nameof(request.DesafioId));

            var participante = await _unitOfWork.ParticipanteRepository.GetByIdAsync(request.ParticipanteId, cancellationToken);
            if (participante == null)
                throw new ArgumentException("Não foi encontrado nenhum participante com este Id.", nameof(request.DesafioId));

            var registroFrequencia = new RegistroFrequencia(new DataFrequencia(request.Data), desafio, participante);

            registroFrequencia.Comparecimento(new Imagem(request.Imagem), Modalidade.FromString(request.Modalidade));

            await _unitOfWork.RegistroFrequenciaRepository.CreateAsync(registroFrequencia, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
