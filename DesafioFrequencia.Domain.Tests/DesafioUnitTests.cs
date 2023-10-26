using DesafioFrequencia.Domain.Exceptions;
using DesafioFrequencia.Domain.Models.Desafios;
using DesafioFrequencia.Domain.Models.Desafios.ValueObjects;
using DesafioFrequencia.Domain.Models.Participantes.ValueObjects;
using DesafioFrequencia.Domain.Models.Participantes;
using FluentAssertions;

namespace DesafioFrequencia.Domain.Tests
{
    public class DesafioUnitTests
    {
        [Fact]
        public void CriarDesafio_DadosValidos_RetornoObjetoValido()
        {
            Action action = () => Desafio.Criar("Marombers 2023.4",
                new Periodo(new DateTime(2023, 06, 01), new DateTime(2023, 06, 30)),
                new Regra(DayOfWeek.Monday, 5)
            );

            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CriarDesafio_NomeInvalido_RetornoObjetoInvalido()
        {
            Action action = () => Desafio.Criar(new string('a', 52),
                new Periodo(new DateTime(2023, 06, 01), new DateTime(2023, 06, 30)),
                new Regra(DayOfWeek.Monday, 5));

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("O nome não pode ter mais que 50 caracteres.");
        }

        [Fact]
        public void CriarDesafio_InicioMaiorQueOFim_RetornoObjetoInvalido()
        {
            Action action = () => Desafio.Criar("Marombers 2023.4",
                new Periodo(new DateTime(2023, 06, 30), new DateTime(2023, 06, 01)),
                new Regra(DayOfWeek.Monday, 5));

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("O fim não pode ser menor que o inicio.");
        }

        [Fact]
        public void CriarDesafio_RegraQuantidadeDiasObrigatorioMenorIgualZero_RetornoObjetoInvalido()
        {
            Action action = () => Desafio.Criar("Marombers 2023.4",
                new Periodo(new DateTime(2023, 06, 01), new DateTime(2023, 06, 30)),
                new Regra(DayOfWeek.Monday, 0));

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("A quantidade de dias obrigatório tem que ser de ao menos 1 dia.");
        }

        [Fact]
        public void CriarDesafio_RegraQuantidadeDiasObrigatorioMaiorQueSete_RetornoObjetoInvalido()
        {
            Action action = () => Desafio.Criar("Marombers 2023.4",
                new Periodo(new DateTime(2023, 06, 01), new DateTime(2023, 06, 30)),
                new Regra(DayOfWeek.Monday, 8));

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("A quantidade de dias obrigatório tem que ser no máximo 7 dias.");
        }

        [Fact]
        public void AlterarNome_DadosValidos_RetornoObjetoValido()
        {
            Action action = () =>
            {
                var desafio = Desafio.Criar("Marombers 2023.4",
                    new Periodo(new DateTime(2023, 06, 01), new DateTime(2023, 06, 30)),
                    new Regra(DayOfWeek.Monday, 5));

                desafio.AlterarNome("Marombers 2023.4");
            };

            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void AlterarNome_DadosInvalidos_RetornoObjetoInvalido()
        {
            Action action = () =>
            {
                var desafio = Desafio.Criar("Marombers 2023.4",
                    new Periodo(new DateTime(2023, 06, 01), new DateTime(2023, 06, 30)),
                    new Regra(DayOfWeek.Monday, 5));

                desafio.AlterarNome(new string('a', 52));
            };

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("O nome não pode ter mais que 50 caracteres.");
        }

        [Fact]
        public void AlterarPeriodo_DadosValidos_RetornoValido()
        {
            Action action = () =>
            {
                var desafio = Desafio.Criar("Marombers 2023.4",
                    new Periodo(new DateTime(2023, 06, 01), new DateTime(2023, 06, 30)),
                    new Regra(DayOfWeek.Monday, 5));

                desafio.AlterarPeriodo(new Periodo(new DateTime(2023, 06, 01), new DateTime(2023, 06, 30)));
            };

            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void AlterarPeriodo_DadosInvalidos_RetornoValido()
        {
            Action action = () =>
            {
                var desafio = Desafio.Criar("Marombers 2023.4",
                    new Periodo(new DateTime(2023, 06, 01), new DateTime(2023, 06, 30)),
                    new Regra(DayOfWeek.Monday, 5));

                desafio.AlterarPeriodo(new Periodo(new DateTime(2023, 06, 30), new DateTime(2023, 06, 01)));
            };

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("O fim não pode ser menor que o inicio.");
        }


        [Fact]
        public void AlterarRegra_RegraQuantidadeDiasObrigatorioMenorIgualZero_RetornoObjetoInvalido()
        {
            Action action = () =>
            {
                var desafio = Desafio.Criar("Marombers 2023.4",
                    new Periodo(new DateTime(2023, 06, 01), new DateTime(2023, 06, 30)),
                    new Regra(DayOfWeek.Monday, 5));

                desafio.AlterarRegra(new Regra(DayOfWeek.Monday, 0));
            };

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("A quantidade de dias obrigatório tem que ser de ao menos 1 dia.");
        }

        [Fact]
        public void AlterarRegra_RegraQuantidadeDiasObrigatorioMaiorQueSete_RetornoObjetoInvalido()
        {
            Action action = () =>
            {
                var desafio = Desafio.Criar("Marombers 2023.4",
                    new Periodo(new DateTime(2023, 06, 01), new DateTime(2023, 06, 30)),
                    new Regra(DayOfWeek.Monday, 5));

                desafio.AlterarRegra(new Regra(DayOfWeek.Monday, 8));
            };

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("A quantidade de dias obrigatório tem que ser no máximo 7 dias.");
        }

        [Fact]
        public void IncluirParticipante_DadosValidos_RetornoObjetoValido()
        {
            Action action = () =>
            {
                var desafio = Desafio.Criar("Marombers 2023.4",
                    new Periodo(new DateTime(2023, 06, 01), new DateTime(2023, 06, 30)),
                    new Regra(DayOfWeek.Monday, 5));

                var participante = Participante.Registrar(
                    1,
                    new NomeCompleto("Renato", "Sabino"),
                    Sexo.Masculino,
                    new DataDeNascimento(new DateTime(1996, 12, 03))
                );

                desafio.IncluirParticipante(participante);
            };

            action.Should()
                .NotThrow<DomainExceptionValidation>();

        }

        [Fact]
        public void IncluirParticipante_ParticipanteRepetido_RetornoObjetoInvalido()
        {
            Action action = () =>
            {
                var desafio = Desafio.Criar("Marombers 2023.4",
                    new Periodo(new DateTime(2023, 06, 01), new DateTime(2023, 06, 30)),
                    new Regra(DayOfWeek.Monday, 5));

                var participante = Participante.Registrar(
                    1,
                    new NomeCompleto("Renato", "Sabino"),
                    Sexo.Masculino,
                    new DataDeNascimento(new DateTime(1996, 12, 03))
                );

                desafio.IncluirParticipante(participante);
                desafio.IncluirParticipante(participante);
            };

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("O participante já está no desafio.");

        }

    }
}

