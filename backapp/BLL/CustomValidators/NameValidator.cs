using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace BLL.CustomValidators
{
    public class NameValidator : ValidationAttribute
    {
        public string OtherProperty { get; set; }
        public NameValidator(string otherProperty)
        {
            OtherProperty = otherProperty;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value != null)
            {
                string? password = value.ToString();
                PropertyInfo? otherprop = validationContext.ObjectType.GetProperty(OtherProperty); //reference to the property
                string? confirm = otherprop.GetValue(validationContext.ObjectInstance).ToString(); //accessing the value of the property
                if(confirm != null)
                {
                    if(password != confirm)
                    {
                        return new ValidationResult(ErrorMessage);
                    }
                    else
                    {
                        return ValidationResult.Success;
                    }
                }
            }
            return null;
        }
    }
}
