using UnitConversion.Application.DTO;
using UnitConversion.Application.Interfaces;

namespace UnitConversion.Application.Services;

public class ConversionService : IConversionService
{
    private readonly IEnumerable<IUnitConverter>
        _converters;

    public ConversionService(
        IEnumerable<IUnitConverter> converters)
    {
        _converters = converters;
    }

    public ConversionResponse Convert(
        ConversionRequest request)
    {
        var converter =
            _converters.FirstOrDefault(c =>
                c.CanConvert(
                    request.FromUnit,
                    request.ToUnit));

        if (converter == null)
        {
            throw new InvalidOperationException("Unsupported conversion.");
        }

        var result =
            converter.Convert(
                request.Value,
                request.FromUnit,
                request.ToUnit);

        return new ConversionResponse
        {
            OriginalValue = request.Value,
            ConvertedValue = result,
            FromUnit = request.FromUnit,
            ToUnit = request.ToUnit
        };
    }
}