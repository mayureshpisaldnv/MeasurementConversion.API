using UnitConversion.Domain.Model;

namespace UnitConversion.Application.Interfaces
{
    public interface IUnitConverter
    {
        UnitCategory Category { get; }

        bool CanConvert(
            string fromUnit,
            string toUnit);

        double Convert(
            double value,
            string fromUnit,
            string toUnit);
    }
}
