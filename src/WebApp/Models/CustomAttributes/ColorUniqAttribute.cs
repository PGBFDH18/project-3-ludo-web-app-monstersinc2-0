using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.CustomAttributes
{
    /// <summary>
    /// Custom Compair Attribute that return error if colors choosen are equal
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class ColorUniqAttributeAttribute : ValidationAttribute
    {


        public string _OtherProperty { get; private set; }

        public ColorUniqAttributeAttribute(string otherProperty)
        {

            _OtherProperty = otherProperty;

        }

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            if (value != null && value.ToString() != "color")
            {
                var otherProperty = validationContext.ObjectInstance.GetType()
                    .GetProperty(_OtherProperty);

                var otherPropertyValue = otherProperty
                    .GetValue(validationContext.ObjectInstance, null);

                if (value.Equals(otherPropertyValue))
                {
                    return new ValidationResult(
                        FormatErrorMessage(validationContext.DisplayName));
                }
            }

            return ValidationResult.Success;
        }
    }


}
