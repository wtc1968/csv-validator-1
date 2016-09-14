﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormatValidator.Validators
{
    public abstract class Validator : IValidator
    {
        private List<ValidationError> _errors;

        public Validator()
        {
            _errors = new List<ValidationError>();
        }

        public abstract bool IsValid(string toCheck);

        public IList<ValidationError> GetErrors()
        {
            return _errors;
        }

        protected List<ValidationError> Errors
        {
            get
            {
                return _errors;
            }
        }
    }
}
