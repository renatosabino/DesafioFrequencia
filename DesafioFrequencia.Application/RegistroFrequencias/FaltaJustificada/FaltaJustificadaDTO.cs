using Microsoft.AspNetCore.Http;

namespace DesafioFrequencia.Application.RegistroFrequencias.FaltaJustificada;

public record FaltaJustificadaDTO(int DesafioId, int ParticipanteId, DateTime Data, IFormFile Imagem);

