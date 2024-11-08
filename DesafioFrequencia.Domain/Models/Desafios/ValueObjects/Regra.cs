﻿using DesafioFrequencia.Domain.Exceptions;

namespace DesafioFrequencia.Domain.Models.Desafios.ValueObjects
{
    public class Regra
    {
        public DayOfWeek InicioDaSemana { get; private set; }
        public int QuantidadeDiasObrigatorio { get; private set; }

        public Regra(DayOfWeek inicioDaSemana, int quantidadeDiasObrigatorio)
        {
            DomainExceptionValidation.When(quantidadeDiasObrigatorio <= 0, "A quantidade de dias obrigatório tem que ser de ao menos 1 dia.");
            DomainExceptionValidation.When(quantidadeDiasObrigatorio > 7, "A quantidade de dias obrigatório tem que ser no máximo 7 dias.");

            InicioDaSemana = inicioDaSemana;
            QuantidadeDiasObrigatorio = quantidadeDiasObrigatorio;
        }
    }
}