using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Internal_System.PM_Validations
{
    class MandatoryRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null || String.IsNullOrEmpty(value.ToString()))
            {
                return new ValidationResult(false, "This field is mandatory");
            }
            return new ValidationResult(true, null);
        }
    }
}
