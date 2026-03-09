namespace QuantityMeasurementApp.Models
{
    public class WeightUnit
    {
        public double ConversionFactor { get; }

        private WeightUnit(double factor)
        {
            ConversionFactor = factor;
        }

        // Static Units
        public static readonly WeightUnit Gram = new WeightUnit(1);
        public static readonly WeightUnit Kilogram = new WeightUnit(1000);
        public static readonly WeightUnit Tonne = new WeightUnit(1000000);

        public double ConvertToBaseUnit(double value)
        {
            return value * ConversionFactor;
        }

        public double ConvertFromBaseUnit(double value)
        {
            return value / ConversionFactor;
        }
    }
}