using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.CustomAttributes
{
    /// <summary>
    /// Custom required Attribute that return error if a palyer name is filled but no color is choosen
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class ColorRequiredAttribute : ValidationAttribute
    {


        public string _OtherProperty { get; private set; } // The player name Property 

        public ColorRequiredAttribute(string otherProperty)
        {

            _OtherProperty = otherProperty;

        }

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            if (value != null && value.ToString() == "color") // If player name is not empty and color not choosen {red, blue, yellow, green}
            {
                var otherProperty = validationContext.ObjectInstance.GetType()
                    .GetProperty(_OtherProperty);

                var otherPropertyValue = otherProperty
                    .GetValue(validationContext.ObjectInstance, null);

                if (otherPropertyValue != null)
                {
                    return new ValidationResult(
                        FormatErrorMessage(validationContext.DisplayName));
                }
            }

            return ValidationResult.Success;
        }
    }
}
