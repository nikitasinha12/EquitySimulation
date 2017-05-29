using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Internal_System.PM_Validations
{
    class PriceRule :ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            //if (!Regex.IsMatch(value.ToString(), @"^[0-9]+$"))
            //{
            //    return new ValidationResult(false, "This Field can have only numbers");
            //}
            if(String.IsNullOrWhiteSpace(value.ToString()))
            {
                return new ValidationResult(false, "This Field cannot be empty");
            }
            else if(Convert.ToInt64(value.ToString())<=0)
            {
                return new ValidationResult(false, "This Field cannot be negative or Zero");
            }
            return new ValidationResult(true, null);
        }
    }
}
