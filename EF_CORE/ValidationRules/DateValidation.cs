using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EF_CORE.ValidationRules
{
    public class DateValidation : ValidationRule
    {

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();

            if (string.IsNullOrEmpty(input))
            {
                return new ValidationResult(false, "Ввод даты в поле обязателен");
            }

            CultureInfo culture = cultureInfo ?? CultureInfo.CurrentCulture;

            if (!DateTime.TryParse(input, culture, DateTimeStyles.None, out DateTime result))
            {
                return new ValidationResult(false, "Введите корректную дату");
            }

            return ValidationResult.ValidResult;
        }

    }
}
