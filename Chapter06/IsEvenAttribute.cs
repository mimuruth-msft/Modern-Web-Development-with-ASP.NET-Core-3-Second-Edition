﻿using System;
using System.ComponentModel.DataAnnotations;

namespace chapter06
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class IsEvenAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                try
                {
                    var convertedValue = Convert.ToDouble(value);
                    var isValid = (convertedValue % 2) == 0;

                    if (!isValid)
                    {
                        return new ValidationResult(this.ErrorMessage,
                        new[] { validationContext.MemberName });
                    }
                }
                catch { }
            }

            return ValidationResult.Success;
        }
    }
}
