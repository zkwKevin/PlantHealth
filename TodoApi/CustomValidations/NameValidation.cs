using System.ComponentModel.DataAnnotations;

namespace TodoApi.CustomValidations
{
    public class NameValidation: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {   
            if( value == null)
            {
                return new ValidationResult("Name field is required");
            }
            var str = value.ToString();
            if(str.Length > 8)
            {
                return new ValidationResult("The max length of name is 8");
            }
            return ValidationResult.Success;
        }
    }
}