using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Services;

public static class LengthConverter
{
    private static double GetFactor(LengthUnit unit)
    {
        return unit switch
        {
            LengthUnit.Inch => 1,
            LengthUnit.Feet => 12,
            LengthUnit.Yards => 36,
            LengthUnit.Centimeters => 0.393701,
            _ => throw new ArgumentException("Invalid unit")
        };
    }

    public static double Convert(double value, LengthUnit source, LengthUnit target)
    {
        if (!double.IsFinite(value))
            throw new ArgumentException("Value must be finite");

        double sourceFactor = GetFactor(source);
        double targetFactor = GetFactor(target);

        return value * (sourceFactor / targetFactor);
    }
}