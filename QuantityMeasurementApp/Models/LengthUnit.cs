namespace QuantityMeasurementApp.Models;

/// <summary>
/// Defines supported length units and their conversion factor to base unit (feet).
/// </summary>
public enum LengthUnit
{
    // Base unit
    Inch,

    // 1 foot = 12 inches
    Feet,

    // 1 yard = 36 inches
    Yards,

    // 1 cm = 0.393701 inches
    Centimeters
}

/// <summary>
/// Helper class for conversion factors.
/// Keeps enum clean but still DRY.
/// </summary>
public static class LengthUnitExtensions
{
    public static double ToInchFactor(this LengthUnit unit)
    {
        return unit switch
        {
            LengthUnit.Inch => 1.0,
            LengthUnit.Feet => 12.0,
            LengthUnit.Yards => 36.0,
            LengthUnit.Centimeters => 0.393701,
            _ => throw new ArgumentOutOfRangeException(nameof(unit))
        };
    }
}