﻿using DesafioFrequencia.Domain.Exceptions;
using DesafioFrequencia.Domain.ValueObjects;

namespace DesafioFrequencia.Domain.Entities
{
    public class Desafio : Entity
    {
        public readonly static int DIAS_NA_SEMANA = 7;
        public string Nome { get; private set; }
        public Periodo Periodo { get; private set; }
        public Regra Regra { get; private set; }

        private readonly List<Participante> _participantes;
        public virtual IReadOnlyCollection<Participante> Participantes => _participantes;

        private readonly List<RegistroFrequencia> _registroFrequencias;
        public virtual IReadOnlyCollection<RegistroFrequencia> RegistroFrequencias => _registroFrequencias;

        private Desafio(string nome, Periodo periodo, Regra regra)
        {
            Nome = nome;
            Periodo = periodo;
            Regra = regra;
        }

        public static Desafio Criar(string nome, Periodo periodo, Regra regra)
        {
            DomainExceptionValidation.When(nome.Length > 50, "O nome não pode ter mais que 50 caracteres.");
            return new Desafio(nome, periodo, regra);
        }

        public void AdicionarParticipante(Participante participante)
        {
            _participantes.Add(participante);
            participante.AdicionarDesafio(this);
        }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }

        public void AlterarPeriodo(Periodo periodo)
        {
            Periodo = periodo;
        }

        public void AlterarRegra(Regra regra)
        {
            Regra = regra;
        }
    }
}
