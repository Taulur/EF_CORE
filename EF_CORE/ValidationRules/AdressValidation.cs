using EF_CORE.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EF_CORE.ValidationRules
{
    public class AdressValidation : ValidationRule
    {
        public StudentsService service { get; set; } = new();
        public override ValidationResult Validate(object value, CultureInfo
        cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();
            if (input == string.Empty)
            {
                return new ValidationResult(false, "Ввод информации в поле обязателен");
            }
            if (input.Length <= 3)
            {
                return new ValidationResult(false, "Должно быть больше трех символов");
            }
            if (!input.Contains('@'))
                return new ValidationResult(false, "Адрес должен иметь символ '@'");
            foreach (Student student in service.Students)
            {
                if (student.Email == input)
                    return new ValidationResult(false, "Такой адрес уже существует");
            }
            return ValidationResult.ValidResult;
        }

    }
}
