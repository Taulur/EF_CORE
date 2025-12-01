using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace EF_CORE.ValidationRules
{
    public class NumberValidation : ValidationRule
    {

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();

            if (string.IsNullOrEmpty(input))
            {
                return new ValidationResult(false, "Ввод номера в поле обязателен");
            }

            CultureInfo culture = cultureInfo ?? CultureInfo.CurrentCulture;

            bool isDigital = true;
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    isDigital = false;
                    break;
                }
            }

            if (!isDigital)
            {
                
                return new ValidationResult(false, "В номере должны быть только цифры");
            }

            if (input.Length > 10)
            {
                return new ValidationResult(false, "В номере должно быть не более 10 цифр");
            }

            if (input.Length < 10)
            {
                return new ValidationResult(false, "В номере должно быть не менее 10 цифр");
            }

            return ValidationResult.ValidResult;
        }

    }
}
