namespace QuantityMeasurementApp.Models
{
    public class LengthUnit
    {
        public double ConversionFactor { get; }

        private LengthUnit(double factor)
        {
            ConversionFactor = factor;
        }

        // Static Units
        public static readonly LengthUnit Inch = new LengthUnit(1);
        public static readonly LengthUnit Feet = new LengthUnit(12);
        public static readonly LengthUnit Yards = new LengthUnit(36);
        public static readonly LengthUnit Centimeters = new LengthUnit(0.393701);

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