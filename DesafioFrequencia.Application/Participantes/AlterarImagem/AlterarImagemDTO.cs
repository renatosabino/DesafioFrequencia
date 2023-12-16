using Microsoft.AspNetCore.Http;

namespace DesafioFrequencia.Application.Participantes.AlterarImagem;
public sealed record AlterarImagemDTO(int Id, IFormFile Imagem);

