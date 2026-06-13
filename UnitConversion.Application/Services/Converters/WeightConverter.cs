using UnitConversion.Application.Interfaces;
using UnitConversion.Domain.Model;

namespace UnitConversion.Application.Services.Converters
{
    public class WeightConverter : IUnitConverter
    {
        public UnitCategory Category =>
            UnitCategory.Weight;

        private readonly Dictionary<string, double> _units =
            new()
            {
                { "kilogram", 1 },
                { "pound", 2.20462 }
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
