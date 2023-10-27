using DesafioFrequencia.Domain.Exceptions;
using DesafioFrequencia.Domain.Models.Desafios;
using DesafioFrequencia.Domain.Models.Desafios.ValueObjects;
using DesafioFrequencia.Domain.Models.Participantes;
using DesafioFrequencia.Domain.Models.RegistroFrequencias;
using DesafioFrequencia.Domain.Models.RegistroFrequencias.ValueObjects;
using FluentAssertions;

namespace DesafioFrequencia.Domain.Tests
{
    public class RegistroFrequenciaUnitTests
    {
        [Fact]
        public void IncluirComparecimento_DadosValidos_InclusaoNovoRegistroFrequencia()
        {
            Action action = () =>
            {
                var desafio = Desafio.Criar("Marombers 2023.4",
                    new Periodo(new DateTime(2023, 06, 01), new DateTime(2023, 06, 30)),
                    new Regra(DayOfWeek.Monday, 5));

                var participante = Participante.Registrar(
                    1,
                    new Models.Participantes.ValueObjects.NomeCompleto("Renato", "Sabino"),
                    Models.Participantes.ValueObjects.Sexo.Masculino,
                    new Models.Participantes.ValueObjects.DataDeNascimento(new DateTime(1996, 12, 03))
                );

                RegistroFrequencia.IncluirComparecimento(new DataFrequencia(new DateTime(2023, 10, 26)),
                    desafio,
                    participante,
                    new Imagem("picture.jpg"));
            };

            action
                .Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void IncluirComparecimento_DadosRepetidos_ErroInclusaoNovoRegistroFrequencia()
        {
            Action action = () =>
            {
                var desafio = Desafio.Criar("Marombers 2023.4",
                    new Periodo(new DateTime(2023, 06, 01), new DateTime(2023, 06, 30)),
                    new Regra(DayOfWeek.Monday, 5));

                var participante = Participante.Registrar(
                    1,
                    new Models.Participantes.ValueObjects.NomeCompleto("Renato", "Sabino"),
                    Models.Participantes.ValueObjects.Sexo.Masculino,
                    new Models.Participantes.ValueObjects.DataDeNascimento(new DateTime(1996, 12, 03))
                );

                RegistroFrequencia.IncluirComparecimento(new DataFrequencia(new DateTime(2023, 10, 26)),
                    desafio,
                    participante,
                    new Imagem("picture.jpg"));

                RegistroFrequencia.IncluirComparecimento(new DataFrequencia(new DateTime(2023, 10, 26)),
                    desafio,
                    participante,
                    new Imagem("picture2.jpg"));
            };

            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Já foi registrado a frequência nesta data.");
        }

        [Fact]
        public void IncluirComparecimento_DataFutura_ErroInclusaoNovoRegistroFrequencia()
        {
            Action action = () =>
            {
                var desafio = Desafio.Criar("Marombers 2023.4",
                    new Periodo(new DateTime(2023, 06, 01), new DateTime(2023, 06, 30)),
                    new Regra(DayOfWeek.Monday, 5));

                var participante = Participante.Registrar(
                    1,
                    new Models.Participantes.ValueObjects.NomeCompleto("Renato", "Sabino"),
                    Models.Participantes.ValueObjects.Sexo.Masculino,
                    new Models.Participantes.ValueObjects.DataDeNascimento(new DateTime(1996, 12, 03))
                );

                RegistroFrequencia.IncluirComparecimento(new DataFrequencia(new DateTime(2099, 12, 31)),
                    desafio,
                    participante,
                    new Imagem("picture.jpg"));
            };

            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("A frequência não pode ser adicionada para o futuro.");
        }

        [Fact]
        public void IncluirComparecimento_ImagemInvalida_ErroInclusaoNovoRegistroFrequencia()
        {
            Action action = () =>
            {
                var desafio = Desafio.Criar("Marombers 2023.4",
                    new Periodo(new DateTime(2023, 06, 01), new DateTime(2023, 06, 30)),
                    new Regra(DayOfWeek.Monday, 5));

                var participante = Participante.Registrar(
                    1,
                    new Models.Participantes.ValueObjects.NomeCompleto("Renato", "Sabino"),
                    Models.Participantes.ValueObjects.Sexo.Masculino,
                    new Models.Participantes.ValueObjects.DataDeNascimento(new DateTime(1996, 12, 03))
                );

                RegistroFrequencia.IncluirComparecimento(new DataFrequencia(new DateTime(2023, 10, 26)),
                    desafio,
                    participante,
                    new Imagem(new string('a', 101)));
            };

            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("O nome da imagem ultrapassou os caracteres suportados.");
        }

        [Fact]
        public void IncluirFalta_DadosValidos_InclusaoNovoRegistroFrequencia()
        {
            Action action = () =>
            {
                var desafio = Desafio.Criar("Marombers 2023.4",
                    new Periodo(new DateTime(2023, 06, 01), new DateTime(2023, 06, 30)),
                    new Regra(DayOfWeek.Monday, 5));

                var participante = Participante.Registrar(
                    1,
                    new Models.Participantes.ValueObjects.NomeCompleto("Renato", "Sabino"),
                    Models.Participantes.ValueObjects.Sexo.Masculino,
                    new Models.Participantes.ValueObjects.DataDeNascimento(new DateTime(1996, 12, 03))
                );

                RegistroFrequencia.IncluirFalta(new DataFrequencia(new DateTime(2023, 10, 26)),
                    desafio,
                    participante,
                    new Imagem("picture.jpg"));
            };

            action
                .Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void IncluirFalta_DadosRepetidos_ErroInclusaoNovoRegistroFrequencia()
        {
            Action action = () =>
            {
                var desafio = Desafio.Criar("Marombers 2023.4",
                    new Periodo(new DateTime(2023, 06, 01), new DateTime(2023, 06, 30)),
                    new Regra(DayOfWeek.Monday, 5));

                var participante = Participante.Registrar(
                    1,
                    new Models.Participantes.ValueObjects.NomeCompleto("Renato", "Sabino"),
                    Models.Participantes.ValueObjects.Sexo.Masculino,
                    new Models.Participantes.ValueObjects.DataDeNascimento(new DateTime(1996, 12, 03))
                );

                RegistroFrequencia.IncluirFalta(new DataFrequencia(new DateTime(2023, 10, 26)),
                    desafio,
                    participante,
                    new Imagem("picture.jpg"));

                RegistroFrequencia.IncluirFalta(new DataFrequencia(new DateTime(2023, 10, 26)),
                    desafio,
                    participante,
                    new Imagem("picture2.jpg"));
            };

            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Já foi registrado a frequência nesta data.");
        }

        [Fact]
        public void IncluirFalta_DataFutura_ErroInclusaoNovoRegistroFrequencia()
        {
            Action action = () =>
            {
                var desafio = Desafio.Criar("Marombers 2023.4",
                    new Periodo(new DateTime(2023, 06, 01), new DateTime(2023, 06, 30)),
                    new Regra(DayOfWeek.Monday, 5));

                var participante = Participante.Registrar(
                    1,
                    new Models.Participantes.ValueObjects.NomeCompleto("Renato", "Sabino"),
                    Models.Participantes.ValueObjects.Sexo.Masculino,
                    new Models.Participantes.ValueObjects.DataDeNascimento(new DateTime(1996, 12, 03))
                );

                RegistroFrequencia.IncluirFalta(new DataFrequencia(new DateTime(2099, 12, 31)),
                    desafio,
                    participante,
                    new Imagem("picture.jpg"));
            };

            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("A frequência não pode ser adicionada para o futuro.");
        }

        [Fact]
        public void IncluirFalta_ImagemInvalida_ErroInclusaoNovoRegistroFrequencia()
        {
            Action action = () =>
            {
                var desafio = Desafio.Criar("Marombers 2023.4",
                    new Periodo(new DateTime(2023, 06, 01), new DateTime(2023, 06, 30)),
                    new Regra(DayOfWeek.Monday, 5));

                var participante = Participante.Registrar(
                    1,
                    new Models.Participantes.ValueObjects.NomeCompleto("Renato", "Sabino"),
                    Models.Participantes.ValueObjects.Sexo.Masculino,
                    new Models.Participantes.ValueObjects.DataDeNascimento(new DateTime(1996, 12, 03))
                );

                RegistroFrequencia.IncluirFalta(new DataFrequencia(new DateTime(2023, 10, 26)),
                    desafio,
                    participante,
                    new Imagem(new string('a', 101)));
            };

            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("O nome da imagem ultrapassou os caracteres suportados.");
        }

        [Fact]
        public void IncluirFaltaJustificada_DadosValidos_InclusaoNovoRegistroFrequencia()
        {
            Action action = () =>
            {
                var desafio = Desafio.Criar("Marombers 2023.4",
                    new Periodo(new DateTime(2023, 06, 01), new DateTime(2023, 06, 30)),
                    new Regra(DayOfWeek.Monday, 5));

                var participante = Participante.Registrar(
                    1,
                    new Models.Participantes.ValueObjects.NomeCompleto("Renato", "Sabino"),
                    Models.Participantes.ValueObjects.Sexo.Masculino,
                    new Models.Participantes.ValueObjects.DataDeNascimento(new DateTime(1996, 12, 03))
                );

                RegistroFrequencia.IncluirFaltaJustificada(new DataFrequencia(new DateTime(2023, 10, 26)),
                    desafio,
                    participante,
                    new Imagem("picture.jpg"));
            };

            action
                .Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void IncluirFaltaJustificada_DadosRepetidos_ErroInclusaoNovoRegistroFrequencia()
        {
            Action action = () =>
            {
                var desafio = Desafio.Criar("Marombers 2023.4",
                    new Periodo(new DateTime(2023, 06, 01), new DateTime(2023, 06, 30)),
                    new Regra(DayOfWeek.Monday, 5));

                var participante = Participante.Registrar(
                    1,
                    new Models.Participantes.ValueObjects.NomeCompleto("Renato", "Sabino"),
                    Models.Participantes.ValueObjects.Sexo.Masculino,
                    new Models.Participantes.ValueObjects.DataDeNascimento(new DateTime(1996, 12, 03))
                );

                RegistroFrequencia.IncluirFaltaJustificada(new DataFrequencia(new DateTime(2023, 10, 26)),
                    desafio,
                    participante,
                    new Imagem("picture.jpg"));

                RegistroFrequencia.IncluirFaltaJustificada(new DataFrequencia(new DateTime(2023, 10, 26)),
                    desafio,
                    participante,
                    new Imagem("picture2.jpg"));
            };

            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Já foi registrado a frequência nesta data.");
        }

        [Fact]
        public void IncluirFaltaJustificada_DataFutura_ErroInclusaoNovoRegistroFrequencia()
        {
            Action action = () =>
            {
                var desafio = Desafio.Criar("Marombers 2023.4",
                    new Periodo(new DateTime(2023, 06, 01), new DateTime(2023, 06, 30)),
                    new Regra(DayOfWeek.Monday, 5));

                var participante = Participante.Registrar(
                    1,
                    new Models.Participantes.ValueObjects.NomeCompleto("Renato", "Sabino"),
                    Models.Participantes.ValueObjects.Sexo.Masculino,
                    new Models.Participantes.ValueObjects.DataDeNascimento(new DateTime(1996, 12, 03))
                );

                RegistroFrequencia.IncluirFaltaJustificada(new DataFrequencia(new DateTime(2099, 12, 31)),
                    desafio,
                    participante,
                    new Imagem("picture.jpg"));
            };

            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("A frequência não pode ser adicionada para o futuro.");
        }

        [Fact]
        public void IncluirFaltaJustificada_ImagemInvalida_ErroInclusaoNovoRegistroFrequencia()
        {
            Action action = () =>
            {
                var desafio = Desafio.Criar("Marombers 2023.4",
                    new Periodo(new DateTime(2023, 06, 01), new DateTime(2023, 06, 30)),
                    new Regra(DayOfWeek.Monday, 5));

                var participante = Participante.Registrar(
                    1,
                    new Models.Participantes.ValueObjects.NomeCompleto("Renato", "Sabino"),
                    Models.Participantes.ValueObjects.Sexo.Masculino,
                    new Models.Participantes.ValueObjects.DataDeNascimento(new DateTime(1996, 12, 03))
                );

                RegistroFrequencia.IncluirFaltaJustificada(new DataFrequencia(new DateTime(2023, 10, 26)),
                    desafio,
                    participante,
                    new Imagem(new string('a', 101)));
            };

            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("O nome da imagem ultrapassou os caracteres suportados.");
        }

        [Fact]
        public void IncluirDayOff_DadosValidos_InclusaoNovoRegistroFrequencia()
        {
            Action action = () =>
            {
                var desafio = Desafio.Criar("Marombers 2023.4",
                    new Periodo(new DateTime(2023, 06, 01), new DateTime(2023, 06, 30)),
                    new Regra(DayOfWeek.Monday, 5));

                var participante = Participante.Registrar(
                    1,
                    new Models.Participantes.ValueObjects.NomeCompleto("Renato", "Sabino"),
                    Models.Participantes.ValueObjects.Sexo.Masculino,
                    new Models.Participantes.ValueObjects.DataDeNascimento(new DateTime(1996, 12, 03))
                );

                RegistroFrequencia.IncluirDayOff(new DataFrequencia(new DateTime(2023, 10, 26)),
                    desafio,
                    participante,
                    new Imagem("picture.jpg"));
            };

            action
                .Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void IncluirDayOff_SemanasDiferentesDadosValidos_InclusaoNovoRegistroFrequencia()
        {
            Action action = () =>
            {
                var desafio = Desafio.Criar("Marombers 2023.4",
                    new Periodo(new DateTime(2023, 06, 01), new DateTime(2023, 06, 30)),
                    new Regra(DayOfWeek.Monday, 5));

                var participante = Participante.Registrar(
                    1,
                    new Models.Participantes.ValueObjects.NomeCompleto("Renato", "Sabino"),
                    Models.Participantes.ValueObjects.Sexo.Masculino,
                    new Models.Participantes.ValueObjects.DataDeNascimento(new DateTime(1996, 12, 03))
                );

                RegistroFrequencia.IncluirDayOff(new DataFrequencia(new DateTime(2023, 10, 19)),
                    desafio,
                    participante,
                    new Imagem("picture.jpg"));

                RegistroFrequencia.IncluirDayOff(new DataFrequencia(new DateTime(2023, 10, 23)),
                    desafio,
                    participante,
                    new Imagem("picture.jpg"));

                RegistroFrequencia.IncluirDayOff(new DataFrequencia(new DateTime(2023, 10, 24)),
                   desafio,
                   participante,
                   new Imagem("picture.jpg"));
            };

            action
                .Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void IncluirDayOff_DadosRepetidos_ErroInclusaoNovoRegistroFrequencia()
        {
            Action action = () =>
            {
                var desafio = Desafio.Criar("Marombers 2023.4",
                    new Periodo(new DateTime(2023, 06, 01), new DateTime(2023, 06, 30)),
                    new Regra(DayOfWeek.Monday, 5));

                var participante = Participante.Registrar(
                    1,
                    new Models.Participantes.ValueObjects.NomeCompleto("Renato", "Sabino"),
                    Models.Participantes.ValueObjects.Sexo.Masculino,
                    new Models.Participantes.ValueObjects.DataDeNascimento(new DateTime(1996, 12, 03))
                );

                RegistroFrequencia.IncluirDayOff(new DataFrequencia(new DateTime(2023, 10, 26)),
                    desafio,
                    participante,
                    new Imagem("picture.jpg"));

                RegistroFrequencia.IncluirDayOff(new DataFrequencia(new DateTime(2023, 10, 26)),
                    desafio,
                    participante,
                    new Imagem("picture2.jpg"));
            };

            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Já foi registrado a frequência nesta data.");
        }

        [Fact]
        public void IncluirDayOff_UltrapassandoLimiteDayOff_ErroNovoRegistroFrequencia()
        {
            Action action = () =>
            {
                var desafio = Desafio.Criar("Marombers 2023.4",
                    new Periodo(new DateTime(2023, 06, 01), new DateTime(2023, 06, 30)),
                    new Regra(DayOfWeek.Monday, 5));

                var participante = Participante.Registrar(
                    1,
                    new Models.Participantes.ValueObjects.NomeCompleto("Renato", "Sabino"),
                    Models.Participantes.ValueObjects.Sexo.Masculino,
                    new Models.Participantes.ValueObjects.DataDeNascimento(new DateTime(1996, 12, 03))
                );

                RegistroFrequencia.IncluirDayOff(new DataFrequencia(new DateTime(2023, 10, 23)),
                    desafio,
                    participante,
                    new Imagem("picture.jpg"));

                RegistroFrequencia.IncluirDayOff(new DataFrequencia(new DateTime(2023, 10, 24)),
                    desafio,
                    participante,
                    new Imagem("picture2.jpg"));

                RegistroFrequencia.IncluirDayOff(new DataFrequencia(new DateTime(2023, 10, 25)),
                    desafio,
                    participante,
                    new Imagem("picture3.jpg"));
            };

            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Já foram incluidos a quantidade máxima de dayoffs na semana.");
        }

        [Fact]
        public void IncluirDayOff_DataFutura_ErroInclusaoNovoRegistroFrequencia()
        {
            Action action = () =>
            {
                var desafio = Desafio.Criar("Marombers 2023.4",
                    new Periodo(new DateTime(2023, 06, 01), new DateTime(2023, 06, 30)),
                    new Regra(DayOfWeek.Monday, 5));

                var participante = Participante.Registrar(
                    1,
                    new Models.Participantes.ValueObjects.NomeCompleto("Renato", "Sabino"),
                    Models.Participantes.ValueObjects.Sexo.Masculino,
                    new Models.Participantes.ValueObjects.DataDeNascimento(new DateTime(1996, 12, 03))
                );

                RegistroFrequencia.IncluirDayOff(new DataFrequencia(new DateTime(2099, 12, 31)),
                    desafio,
                    participante,
                    new Imagem("picture.jpg"));
            };

            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("A frequência não pode ser adicionada para o futuro.");
        }

        [Fact]
        public void IncluirDayOff_ImagemInvalida_ErroInclusaoNovoRegistroFrequencia()
        {
            Action action = () =>
            {
                var desafio = Desafio.Criar("Marombers 2023.4",
                    new Periodo(new DateTime(2023, 06, 01), new DateTime(2023, 06, 30)),
                    new Regra(DayOfWeek.Monday, 5));

                var participante = Participante.Registrar(
                    1,
                    new Models.Participantes.ValueObjects.NomeCompleto("Renato", "Sabino"),
                    Models.Participantes.ValueObjects.Sexo.Masculino,
                    new Models.Participantes.ValueObjects.DataDeNascimento(new DateTime(1996, 12, 03))
                );

                RegistroFrequencia.IncluirDayOff(new DataFrequencia(new DateTime(2023, 10, 26)),
                    desafio,
                    participante,
                    new Imagem(new string('a', 101)));
            };

            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("O nome da imagem ultrapassou os caracteres suportados.");
        }
    }
}
