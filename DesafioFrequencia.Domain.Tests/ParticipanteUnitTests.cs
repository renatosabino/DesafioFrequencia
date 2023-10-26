﻿using DesafioFrequencia.Domain.Models.Participantes;
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
                1,
                new NomeCompleto("Renato", "Sabino"),
                Sexo.Masculino,
                new DataDeNascimento(new DateTime(1996, 12, 03))
            );

            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void RegistrarParticipante_IdInvalido_RetornoObjetoInvalido()
        {
            Action action = () => Participante.Registrar(
                -1,
                new NomeCompleto("Renato", "Sabino"),
                Sexo.Masculino,
                new DataDeNascimento(new DateTime(1996, 12, 03))
            );

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Id com valor inválido.");
        }

        [Fact]
        public void RegistrarParticipante_NomeInvalido_RetornoObjetoInvalido()
        {
            Action action = () => Participante.Registrar(
                1,
                new NomeCompleto(new string('A', 51), "Sabino"),
                Sexo.Masculino,
                new DataDeNascimento(new DateTime(1996, 12, 03))
            );

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("O Nome ultrapassou a quantidade de caracteres suportados.");
        }

        [Fact]
        public void RegistrarParticipante_SobrenomeInvalido_RetornoObjetoInvalido()
        {
            Action action = () => Participante.Registrar(
                1,
                new NomeCompleto("Renato", new string('A', 101)),
                Sexo.Masculino,
                new DataDeNascimento(new DateTime(1996, 12, 03))
            );

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("O Sobrenome ultrapassou a quantidade de caracteres suportados.");
        }

        [Fact]
        public void RegistrarParticipante_SexoInvalido_RetornoObjetoInvalido()
        {
            Action action = () => Participante.Registrar(
                1,
                new NomeCompleto("Renato", "Sabino"),
                Sexo.FromString("ABC"),
                new DataDeNascimento(new DateTime(1996, 12, 03))
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
            Action action = () => new Imagem(new string('a', 200));

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("O nome da imagem ultrapassou os caracteres suportados.");
        }
    }
}