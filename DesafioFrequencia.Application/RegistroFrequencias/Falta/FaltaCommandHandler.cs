using DesafioFrequencia.Domain.Interfaces;
using DesafioFrequencia.Domain.Models.RegistroFrequencias;
using DesafioFrequencia.Domain.Models.RegistroFrequencias.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioFrequencia.Application.RegistroFrequencias.Falta
{
    public class FaltaCommandHandler : IRequestHandler<FaltaCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public FaltaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(FaltaCommand request, CancellationToken cancellationToken)
        {
            var desafio = await _unitOfWork.DesafioRepository.GetByIdAsync(request.DesafioId, cancellationToken);
            if (desafio == null)
                throw new ArgumentException("Não foi encontrado nenhum desafio com este Id.", nameof(request.DesafioId));

            var participante = await _unitOfWork.ParticipanteRepository.GetByIdAsync(request.ParticipanteId, cancellationToken);
            if (participante == null)
                throw new ArgumentException("Não foi encontrado nenhum participante com este Id.", nameof(request.DesafioId));

            var registroFrequencia = new RegistroFrequencia(new DataFrequencia(request.Data), desafio, participante);

            registroFrequencia.Falta();

            await _unitOfWork.RegistroFrequenciaRepository.CreateAsync(registroFrequencia, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
