using DesafioFrequencia.Domain.Interfaces;
using DesafioFrequencia.Domain.Models.Participantes;
using DesafioFrequencia.Domain.Models.Participantes.ValueObjects;
using MediatR;

namespace DesafioFrequencia.Application.Participantes.Registrar
{
    public class RegistrarCommandHandler : IRequestHandler<RegistrarCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegistrarCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RegistrarCommand request, CancellationToken cancellationToken)
        {
            var participante = Participante.Registrar(
                new NomeCompleto(request.Nome, request.Sobrenome),
                Sexo.FromString(request.Sexo),
                new DataDeNascimento(request.DataDeNascimento)
            );

            await _unitOfWork.ParticipanteRepository.CreateAsync(participante, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
