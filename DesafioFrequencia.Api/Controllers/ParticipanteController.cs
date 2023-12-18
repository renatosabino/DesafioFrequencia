using DesafioFrequencia.Application.Participantes.AlterarImagem;
using DesafioFrequencia.Application.Participantes.Editar;
using DesafioFrequencia.Application.Participantes.Registrar;
using DesafioFrequencia.Infra.Utils.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioFrequencia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ParticipanteController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IImageUploadService _imageUploadService;
        private readonly IConfiguration _configuration;

        public ParticipanteController(IMediator mediator, IImageUploadService imageUploadService, IConfiguration configuration)
        {
            _mediator = mediator;
            _imageUploadService = imageUploadService;
            _configuration = configuration;
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] RegistrarCommand registrar, CancellationToken cancellationToken)
        {
            await _mediator.Send(registrar, cancellationToken);
            return Ok();
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] EditarCommand editar, CancellationToken cancellationToken)
        {
            await _mediator.Send(editar, cancellationToken);
            return Ok();
        }

        [HttpPut("AlterarImagem")]
        public async Task<IActionResult> AlterarImagem([FromForm] AlterarImagemDTO alterarImagem, CancellationToken cancellationToken)
        {

            var folder = _configuration["ImageUploadFolders:ParticipanteFolder"];
            var imagem = await _imageUploadService.UploadImageAsync(alterarImagem.Imagem, folder);

            var alterarImagemCommand = new AlterarImagemCommand(alterarImagem.Id, imagem);

            await _mediator.Send(alterarImagemCommand, cancellationToken);
            return Ok();
        }
    }
}
