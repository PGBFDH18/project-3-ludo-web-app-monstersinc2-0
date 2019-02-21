using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.BindingModel
{
    /// <summary>
    /// Custom Attribute that validate a player not null string when binding/Meaning => empty string
    /// </summary>
    public class PlayerCustomAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var code = value as string;
            if (code == null)
            {
                return new ValidationResult("Field Can't be empty");
            }
            return ValidationResult.Success;
        }
    }



}
