using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace SendMailWPF.Logic
{
    internal class DataValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex pattern = new Regex(@"^([0-9a-zA-Z]" + 
                                      @"([\+\-_\.][0-9a-zA-Z]+)*" + 
                                      @")+" +
                                      @"@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,17})$");

            
            string eMail = value.ToString();
            
            if (pattern.IsMatch(eMail))
            {
                return new ValidationResult(true, null);
            }
            else
            {
                return new ValidationResult(false, "eMail введён некорректно!");
            }
        }
    }
}
