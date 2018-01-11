using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace POP54.Validation
{
    class IntValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string v = value as string; 
            v.Trim();
            if (v == null || v == "")
                return new ValidationResult(false, "You must fill in this field");
            else if(v.Length > 0)
            {
                try
                {
                    var num = int.Parse(v);
                    if (num < 0)
                        return new ValidationResult(false, "Number must be greater than 0");
                }catch(Exception )
                {
                    return new ValidationResult(false, "You must enter a number");
                }
            }
            return new ValidationResult(true, "");
            
         
        }
    }
}
