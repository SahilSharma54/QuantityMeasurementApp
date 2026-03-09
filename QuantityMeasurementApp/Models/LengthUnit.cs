namespace QuantityMeasurementApp.Models;

/// <summary>
/// Standalone enum responsible for unit conversion.
/// Each unit knows how to convert to and from base unit (Feet).
/// </summary>
public enum LengthUnit
{
    Feet,
    Inch,
    Yards,
    Centimeters
}

public static class LengthUnitExtensions
{
    /// Convert given value to base unit (Feet)
    public static double ConvertToBaseUnit(this LengthUnit unit, double value)
    {
        return unit switch
        {
            LengthUnit.Feet => value,
            LengthUnit.Inch => value / 12.0,
            LengthUnit.Yards => value * 3.0,
            LengthUnit.Centimeters => value / 30.48,
            _ => throw new ArgumentException("Unsupported unit")
        };
    }

    /// Convert base unit (Feet) to target unit
    public static double ConvertFromBaseUnit(this LengthUnit unit, double baseValue)
    {
        return unit switch
        {
            LengthUnit.Feet => baseValue,
            LengthUnit.Inch => baseValue * 12.0,
            LengthUnit.Yards => baseValue / 3.0,
            LengthUnit.Centimeters => baseValue * 30.48,
            _ => throw new ArgumentException("Unsupported unit")
        };
    }
}