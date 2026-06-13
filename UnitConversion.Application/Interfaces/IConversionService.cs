using UnitConversion.Application.DTO;

using UnitConversion.Application.DTO;

namespace UnitConversion.Application.Interfaces
{
    public interface IConversionService
    {
        ConversionResponse Convert(
            ConversionRequest request);
    }
}
