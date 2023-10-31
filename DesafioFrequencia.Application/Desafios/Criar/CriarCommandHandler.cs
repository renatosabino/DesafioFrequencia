using DesafioFrequencia.Domain.Interfaces;
using DesafioFrequencia.Domain.Models.Desafios;
using DesafioFrequencia.Domain.Models.Desafios.ValueObjects;
using MediatR;

namespace DesafioFrequencia.Application.Desafios.Criar
{
    public class CriarCommandHandler : IRequestHandler<CriarCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CriarCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CriarCommand request, CancellationToken cancellationToken)
        {
            var desafio = Desafio.Criar(request.Nome, 
                new Periodo(request.Inicio, request.Fim), 
                new Regra(request.InicioDaSemana, request.QuantidadeDiasObrigatorio));

            await _unitOfWork.DesafioRepository.CreateAsync(desafio, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
