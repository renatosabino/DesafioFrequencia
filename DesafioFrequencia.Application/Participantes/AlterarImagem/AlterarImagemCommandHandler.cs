using DesafioFrequencia.Domain.Interfaces;
using DesafioFrequencia.Domain.Models.Participantes.ValueObjects;
using MediatR;

namespace DesafioFrequencia.Application.Participantes.AlterarImagem
{
    public class AlterarImagemCommandHandler : IRequestHandler<AlterarImagemCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AlterarImagemCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(AlterarImagemCommand request, CancellationToken cancellationToken)
        {
            var participante = await _unitOfWork.ParticipanteRepository.GetByIdAsync(request.Id, cancellationToken);

            if (participante is null)
                throw new ArgumentException("Não foi encontrado nenhum participante com este Id.", nameof(request.Id));

            participante.AlterarImagem(new Imagem(request.Imagem));

            _unitOfWork.ParticipanteRepository.Update(participante);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
