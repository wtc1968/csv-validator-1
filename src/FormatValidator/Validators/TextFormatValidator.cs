﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FormatValidator.Validators
{
    public class TextFormatValidator : IValidator
    {
        private Regex _format;
        private List<ValidationError> _errors;

        public TextFormatValidator(string format)
        {
            _errors = new List<ValidationError>();
            _format = new Regex(format);
        }

        public bool IsValid(string toCheck)
        {
            bool isValid = _format.IsMatch(toCheck);
            if(!isValid)
            {
                _errors.Add(new ValidationError(0, string.Format("String {0} was not in correct format.", toCheck)));
            }
            return _format.IsMatch(toCheck);
        }

        public IList<ValidationError> GetErrors()
        {
            return _errors;
        }

    }
}
