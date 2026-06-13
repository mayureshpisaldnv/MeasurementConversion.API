namespace UnitConversion.Domain.Model
{
    public class UnitDefinition
    {
        public string Name { get; set; } = string.Empty;

        public UnitCategory Category { get; set; }

        public double FactorToBase { get; set; }
    }
}
