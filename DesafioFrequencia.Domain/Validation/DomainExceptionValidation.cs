﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioFrequencia.Domain.Exceptions
{
    public class DomainExceptionValidation : Exception
    {
        private DomainExceptionValidation(string error) : base(error) { }

        public static void When(bool hasError, string error)
        {
            if(hasError)
            {
                throw new DomainExceptionValidation(error);
            }
        }
    }
}
