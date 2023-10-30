using DesafioFrequencia.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioFrequencia.Application.Participantes.AlterarImagem
{
    public class AlterarImagemCommandHandler : IRequestHandler<AlterarImagemCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AlterarImagemCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task Handle(AlterarImagemCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
