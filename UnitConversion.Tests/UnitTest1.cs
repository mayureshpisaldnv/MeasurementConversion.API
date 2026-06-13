using FluentAssertions;
using UnitConversion.Application.Services.Converters;

namespace UnitConversion.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void MeterToFoot_ShouldConvert()
        {
            var converter =
                new LengthConverter();

            var result =
                converter.Convert(
                    1,
                    "meter",
                    "foot");

            result.Should()
                  .BeApproximately(
                      3.28084,
                      0.001);
        }

        [Fact]
        public void KilogramToPound_ShouldConvert()
        {
            var converter =
                new WeightConverter();

            var result =
                converter.Convert(
                    1,
                    "kilogram",
                    "pound");

            result.Should()
                  .BeApproximately(
                      2.20462,
                      0.001);
        }

        [Fact]
        public void CelsiusToFahrenheit_ShouldConvert()
        {
            var converter =
                new TemperatureConverter();

            var result =
                converter.Convert(
                    0,
                    "celsius",
                    "fahrenheit");

            result.Should().Be(32);
        }
    }
}
