using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;

namespace Translaterr.Transman.Api.Validators
{
    public class LanguageCode : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var inputString = value as string;

            if (inputString == null)
            {
                return true;
            }
            
            if (inputString == string.Empty)
            {
                return false;
            }
            
            return CultureInfo
                .GetCultures(CultureTypes.AllCultures)
                .Any(culture => string.Equals(
                    culture.Name, 
                    inputString, 
                    StringComparison.CurrentCultureIgnoreCase));
        }
    }
}