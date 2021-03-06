﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace POP54.Validation
{
    class StringValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (((string)value) == null || ((string)value).Length == 0) 
                return new ValidationResult(false, "You must fill in this field");
            else
                return new ValidationResult(true, "");
        }
    }
}
