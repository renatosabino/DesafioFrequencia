using DesafioFrequencia.Application.Desafios.AlterarNome;
using DesafioFrequencia.Application.Desafios.AlterarPeriodo;
using DesafioFrequencia.Application.Desafios.AlterarRegra;
using DesafioFrequencia.Application.Desafios.Criar;
using DesafioFrequencia.Application.Desafios.IncluirParticipante;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioFrequencia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DesafioController : Controller
    {
        private readonly IMediator _mediator;

        public DesafioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Criar([FromBody] CriarCommand criar, CancellationToken cancellationToken)
        {
            await _mediator.Send(criar, cancellationToken);
            return Ok();
        }

        [HttpPut("AlterarNome")]
        public async Task<IActionResult> AlterarNome([FromBody] AlterarNomeCommand alterarNome, CancellationToken cancellationToken)
        {
            await _mediator.Send(alterarNome, cancellationToken);
            return Ok();
        }

        [HttpPut("AlterarRegra")]
        public async Task<IActionResult> AlterarRegra([FromBody] AlterarRegraCommand alterarRegra, CancellationToken cancellationToken)
        {
            await _mediator.Send(alterarRegra, cancellationToken);
            return Ok();
        }

        [HttpPut("AlterarPeriodo")]
        public async Task<IActionResult> AlterarPeriodo([FromBody] AlterarPeriodoCommand alterarPeriodo, CancellationToken cancellationToken)
        {
            await _mediator.Send(alterarPeriodo, cancellationToken);
            return Ok();
        }

        [HttpPost("IncluirParticipante")]
        public async Task<IActionResult> IncluirParticipante([FromBody] IncluirParticipanteCommand incluirParticipante, CancellationToken cancellationToken)
        {
            await _mediator.Send(incluirParticipante, cancellationToken);
            return Ok();
        }
    }
}
