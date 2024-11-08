﻿using DesafioFrequencia.Domain.Exceptions;

namespace DesafioFrequencia.Domain.Models.RegistroFrequencias.ValueObjects
{
    public class DataFrequencia
    {
        public DateTime Data { get; set; }

        public DataFrequencia(DateTime data)
        {
            DomainExceptionValidation.When(data > DateTime.Now, "A frequência não pode ser adicionada para o futuro.");
            Data = data;
        }
    }
}
