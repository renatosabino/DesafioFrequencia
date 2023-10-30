using DesafioFrequencia.Domain.Interfaces;
using DesafioFrequencia.Domain.Models.Participantes.ValueObjects;
using MediatR;

namespace DesafioFrequencia.Application.Participantes.Editar
{
    public class EditarCommandHandler : IRequestHandler<EditarCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditarCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(EditarCommand request, CancellationToken cancellationToken)
        {
            var participante = await _unitOfWork.ParticipanteRepository.GetByIdAsync(request.Id, cancellationToken);

            if (participante is null)
                throw new ArgumentException("Não foi encontrado nenhum participante com este Id.", nameof(request.Id));

            participante.Editar(
                new NomeCompleto(request.Nome, request.Sobrenome),
                Sexo.FromString(request.Sexo),
                new DataDeNascimento(request.DataDeNascimento)
                );

            _unitOfWork.ParticipanteRepository.Update(participante);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
