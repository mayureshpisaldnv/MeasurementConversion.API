using System.ComponentModel.DataAnnotations;

namespace UnitConversion.Application.DTO
{
    public class ConversionRequest
    {
        public double Value { get; set; }

        [Required]
        [RegularExpression(
            "(?i)^(meter|foot|kilometer|kilogram|pound|celsius|fahrenheit)$",
            ErrorMessage = "FromUnit is not supported.")]
        public string FromUnit { get; set; } = string.Empty;

        [Required]
        [RegularExpression(
            "(?i)^(meter|foot|kilometer|kilogram|pound|celsius|fahrenheit)$",
            ErrorMessage = "ToUnit is not supported.")]
        public string ToUnit { get; set; } = string.Empty;
    }
}
