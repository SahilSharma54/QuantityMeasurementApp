namespace QuantityMeasurementApp.Models;

/// <summary>
/// Generic quantity class representing length with value + unit.
/// Eliminates duplication between Feet and Inch.
/// </summary>
public class QuantityLength
{
    public double Value { get; }
    public LengthUnit Unit { get; }

    public QuantityLength(double value, LengthUnit unit)
    {
        if (double.IsNaN(value))
            throw new ArgumentException("Value must be numeric");

        Value = value;
        Unit = unit;
    }

    /// <summary>
    /// Converts measurement to base unit (feet).
    /// </summary>
    private double ConvertToBase()
    {
        return Value * Unit.ToInchFactor();
    }

    /// <summary>
    /// Equality comparison using base conversion.
    /// Supports cross-unit equality (UC3 main feature).
    /// </summary>
    public override bool Equals(object? obj)
    {
        if (obj is null || obj is not QuantityLength other)
            return false;

        double a = ConvertToBase();
        double b = other.ConvertToBase();

        return Math.Abs(a - b) < 0.0001;
    }

    public override int GetHashCode()
    {
        return ConvertToBase().GetHashCode();
    }
}