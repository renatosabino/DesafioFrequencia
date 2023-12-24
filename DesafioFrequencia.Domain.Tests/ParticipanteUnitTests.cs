using DesafioFrequencia.Domain.Models.Participantes;
using FluentAssertions;
using DesafioFrequencia.Domain.Models.Participantes.ValueObjects;
using DesafioFrequencia.Domain.Exceptions;

namespace DesafioFrequencia.Domain.Tests
{
    public class ParticipanteUnitTests
    {
        [Fact]
        public void RegistrarParticipante_DadosValidos_RetornoObjetoValido()
        {
            Action action = () => Participante.Registrar(
                new NomeCompleto("Renato", "Sabino"),
                Sexo.Masculino,
                new DataDeNascimento(new DateTime(1996, 12, 03)),
                new Email("resabino1996@gmail.com")
            );

            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void RegistrarParticipante_NomeInvalido_RetornoObjetoInvalido()
        {
            Action action = () => Participante.Registrar(
                new NomeCompleto(new string('A', 51), "Sabino"),
                Sexo.Masculino,
                new DataDeNascimento(new DateTime(1996, 12, 03)),
                new Email("resabino1996@gmail.com")
            );

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("O Nome ultrapassou a quantidade de caracteres suportados.");
        }

        [Fact]
        public void RegistrarParticipante_SobrenomeInvalido_RetornoObjetoInvalido()
        {
            Action action = () => Participante.Registrar(
                new NomeCompleto("Renato", new string('A', 101)),
                Sexo.Masculino,
                new DataDeNascimento(new DateTime(1996, 12, 03)),
                new Email("resabino1996@gmail.com")
            );

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("O Sobrenome ultrapassou a quantidade de caracteres suportados.");
        }

        [Fact]
        public void RegistrarParticipante_EmailInvalido_RetornoObjetoInvalido()
        {
            Action action = () => Participante.Registrar(
                new NomeCompleto("Renato", "Sabino"),
                Sexo.Masculino,
                new DataDeNascimento(new DateTime(1996, 12, 03)),
                new Email("resabino1996")
            );

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("O email é inválido.");
        }

        [Fact]
        public void RegistrarParticipante_SexoInvalido_RetornoObjetoInvalido()
        {
            Action action = () => Participante.Registrar(
                new NomeCompleto("Renato", "Sabino"),
                Sexo.FromString("ABC"),
                new DataDeNascimento(new DateTime(1996, 12, 03)),
                new Email("resabino1996@gmail.com")
            );

            action.Should()
                .Throw<ArgumentException>()
                .WithMessage("Sexo inválido");
        }

        [Fact]
        public void AlterarImagem_ImagemValida_RetornoObjetoValido()
        {
            Action action = () => new Imagem("teste.png");

            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void AlterarImagem_ImagemInvalida_RetornoObjetoInvalido()
        {

            Action action = () =>
            {
                var participante = Participante.Registrar(
                        new NomeCompleto("Renato", "Sabno"),
                        Sexo.Masculino,
                        new DataDeNascimento(new DateTime(1996, 12, 03)),
                        new Email("resabino1996@gmail.com")
                    );

                participante.AlterarImagem(new Imagem(new string('a', 200)));
            };

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("O nome da imagem ultrapassou os caracteres suportados.");
        }

        [Fact]
        public void EditarParticipante_DadosValidos_RetornoObjetoValido()
        {
            Action action = () =>
            {
                var participante = Participante.Registrar(
                    new NomeCompleto("Renato", "Sabno"),
                    Sexo.Masculino,
                    new DataDeNascimento(new DateTime(1996, 12, 03)),
                    new Email("resabino1996@gmail.com")
                );

                participante.Editar(
                    new NomeCompleto("Renato", "Sabino"),
                    Sexo.Masculino,
                    new DataDeNascimento(new DateTime(1996, 12, 03))
                );
            };

            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }
    }
}
