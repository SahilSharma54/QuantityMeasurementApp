using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Services
{
    public class LengthConverter
    {
        public static double Convert(double value, LengthUnit fromUnit, LengthUnit toUnit)
        {
            double baseValue = fromUnit.ConvertToBaseUnit(value);
            return toUnit.ConvertFromBaseUnit(baseValue);
        }
    }
}