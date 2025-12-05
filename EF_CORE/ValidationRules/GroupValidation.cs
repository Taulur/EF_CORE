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
    public class GroupValidation : ValidationRule
    {
        InterestGroupService service = new InterestGroupService();
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
 
            foreach (InterestGroup group in service.InterestGroups)
            {
                if (group.Title == input)
                    return new ValidationResult(false, "Такая группа уже существует");
            }
            return ValidationResult.ValidResult;
        }
    }
}
