using EF_CORE.Data;
using EF_CORE.Service;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EF_CORE.ValidationRules
{
    public class LoginValidation : ValidationRule
    {
        StudentsService studentsService = new StudentsService();
        public override ValidationResult Validate(object value, CultureInfo
        cultureInfo)
        {
            var input = (value ?? "").ToString().Trim().ToLower();
            if (input == string.Empty)
            {
                return new ValidationResult(false, "Ввод информации в поле обязателен");
            }
            if (input.Length <= 5)
            {
                return new ValidationResult(false, "Должно быть больше пяти символов");
            }
            foreach (Student student in studentsService.Students)
            {
                if (student.Login == input)
                    return new ValidationResult(false, "Такой логин уже существует");
            }
            return ValidationResult.ValidResult;
        }

    }
}
