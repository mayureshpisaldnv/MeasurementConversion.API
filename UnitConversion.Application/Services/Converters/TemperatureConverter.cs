using UnitConversion.Application.Interfaces;
using UnitConversion.Domain.Model;

namespace UnitConversion.Application.Services.Converters
{
    public class TemperatureConverter : IUnitConverter
    {
        private static readonly HashSet<string> _units =
            ["celsius", "fahrenheit"];

        public UnitCategory Category =>
            UnitCategory.Temperature;

        public bool CanConvert(
            string fromUnit,
            string toUnit)
        {
            fromUnit = fromUnit.ToLowerInvariant();
            toUnit = toUnit.ToLowerInvariant();

            return _units.Contains(fromUnit)
                && _units.Contains(toUnit)
                && fromUnit != toUnit;
        }

        public double Convert(
            double value,
            string fromUnit,
            string toUnit)
        {
            fromUnit = fromUnit.ToLowerInvariant();
            toUnit = toUnit.ToLowerInvariant();

            if (fromUnit == "celsius"
                && toUnit == "fahrenheit")
            {
                return value * 9 / 5 + 32;
            }

            if (fromUnit == "fahrenheit"
                && toUnit == "celsius")
            {
                return (value - 32) * 5 / 9;
            }

            throw new InvalidOperationException();
        }
    }
}
