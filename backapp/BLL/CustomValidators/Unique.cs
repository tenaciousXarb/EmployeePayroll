using BLL.DTO.MainDTO;
using BLL.Services;
using DAL.EF;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace BLL.CustomValidators
{
    public class Unique : ValidationAttribute
    {
        #region other property
        /*public string OtherProperty { get; set; }
        public UniqueUsername(string otherProperty)
        {
            OtherProperty = otherProperty;
        }*/ 
        #endregion

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value != null)
            {
                string? username = value.ToString();
                var employees = Task.Run(() => EmployeeService.Get()).Result;
                if(employees != null)
                {
                    if(employees.Any(x => x.Username == username))
                    {
                        return new ValidationResult(ErrorMessage);
                    }
                    else
                    {
                        return ValidationResult.Success;
                    }
                }
                #region other property
                /*PropertyInfo? otherprop = validationContext.ObjectType.GetProperty(OtherProperty); //reference to the property
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
                        }*/ 
                #endregion
            }
            return null;
        }
    }
}
