using UnitConversion.Application.Interfaces;
using UnitConversion.Domain.Model;

namespace UnitConversion.Application.Services.Converters
{
    public class LengthConverter : IUnitConverter
    {
        public UnitCategory Category =>
            UnitCategory.Length;

        private readonly Dictionary<string, double> _units =
            new()
            {
                { "meter", 1 },
                { "foot", 3.28084 },
                { "kilometer", 0.001 }
            };

        public bool CanConvert(
            string fromUnit,
            string toUnit)
        {
            fromUnit = fromUnit.ToLowerInvariant();
            toUnit = toUnit.ToLowerInvariant();

            return _units.ContainsKey(fromUnit)
                && _units.ContainsKey(toUnit);
        }

        public double Convert(
            double value,
            string fromUnit,
            string toUnit)
        {
            fromUnit = fromUnit.ToLowerInvariant();
            toUnit = toUnit.ToLowerInvariant();

            return value /
                   _units[fromUnit] *
                   _units[toUnit];
        }
    }
}
