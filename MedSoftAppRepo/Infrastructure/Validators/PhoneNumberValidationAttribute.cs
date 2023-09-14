using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class PhoneNumberValidationAttribute : ValidationAttribute
{
    private const string Pattern = @"^5\d{8}$";

    public override bool IsValid(object value)
    {
        if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
        {
            return false;
        }
        string phoneNumber = value.ToString();
        return Regex.IsMatch(phoneNumber, Pattern);
    }
}