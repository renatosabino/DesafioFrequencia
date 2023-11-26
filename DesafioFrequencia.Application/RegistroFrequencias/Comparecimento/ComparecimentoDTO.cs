using Microsoft.AspNetCore.Http;

namespace DesafioFrequencia.Application.RegistroFrequencias.Comparecimento;

public record ComparecimentoDTO(int DesafioId, int ParticipanteId, DateTime Data, string Modalidade, IFormFile Imagem);

