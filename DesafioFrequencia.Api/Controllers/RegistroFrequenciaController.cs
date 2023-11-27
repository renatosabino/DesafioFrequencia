using DesafioFrequencia.Application.RegistroFrequencias.Comparecimento;
using DesafioFrequencia.Application.RegistroFrequencias.DayOff;
using DesafioFrequencia.Application.RegistroFrequencias.Falta;
using DesafioFrequencia.Application.RegistroFrequencias.FaltaJustificada;
using DesafioFrequencia.Infra.Utils.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DesafioFrequencia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroFrequenciaController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IImageUploadService _imageUploadService;
        private readonly IConfiguration _configuration;

        public RegistroFrequenciaController(IMediator mediator,
            IImageUploadService imageUploadService,
            IConfiguration configuration)
        {
            _mediator = mediator;
            _imageUploadService = imageUploadService;
            _configuration = configuration;
        }

        [HttpPost("DayOff")]
        public async Task<IActionResult> DayOff([FromBody] DayOffCommand dayOff, CancellationToken cancellationToken)
        {
            await _mediator.Send(dayOff, cancellationToken);
            return Ok();
        }

        [HttpPost("Falta")]
        public async Task<IActionResult> Falta([FromBody] FaltaCommand falta, CancellationToken cancellationToken)
        {
            await _mediator.Send(falta, cancellationToken);
            return Ok();
        }

        [HttpPost("Comparecimento")]
        public async Task<IActionResult> Comparecimento([FromForm] ComparecimentoDTO comparecimento, CancellationToken cancellationToken)
        {
            var folder = _configuration["ImageUploadFolders:ComparecimentoFolder"];
            var imagem = await _imageUploadService.UploadImageAsync(comparecimento.Imagem, folder);

            var comparecimentoCommand = new ComparecimentoCommand(
                comparecimento.DesafioId,
                comparecimento.ParticipanteId,
                comparecimento.Data,
                imagem,
                comparecimento.Modalidade
                );

            await _mediator.Send(comparecimentoCommand, cancellationToken);

            return Ok();
        }

        [HttpPost("FaltaJustificada")]
        public async Task<IActionResult> FaltaJustificada([FromForm] FaltaJustificadaDTO faltaJustificada, CancellationToken cancellationToken)
        {
            var folder = _configuration["ImageUploadFolders:FaltaJustificadaFolder"];
            var imagem = await _imageUploadService.UploadImageAsync(faltaJustificada.Imagem, folder);

            var comparecimentoCommand = new FaltaJustificadaCommand(
                faltaJustificada.DesafioId,
                faltaJustificada.ParticipanteId,
                faltaJustificada.Data,
                imagem
                );

            await _mediator.Send(comparecimentoCommand, cancellationToken);

            return Ok();
        }
    }
}
