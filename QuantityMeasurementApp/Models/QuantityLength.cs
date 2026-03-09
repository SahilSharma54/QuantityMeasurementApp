namespace QuantityMeasurementApp.Models;

/// <summary>
/// Represents a length measurement with value and unit
/// </summary>
public class QuantityLength
{
    public double Value { get; }
    public LengthUnit Unit { get; }

    public QuantityLength(double value, LengthUnit unit)
    {
        if (!double.IsFinite(value))
            throw new ArgumentException("Invalid numeric value");

        Value = value;
        Unit = unit;
    }

    /// <summary>
    /// Convert current quantity to base unit (Feet)
    /// </summary>
    private double ToFeet()
    {
        return Unit switch
        {
            LengthUnit.Feet => Value,
            LengthUnit.Inch => Value / 12,
            LengthUnit.Yards => Value * 3,
            LengthUnit.Centimeters => Value / 30.48,
            _ => throw new ArgumentException("Unsupported Unit")
        };
    }

    /// <summary>
    /// Convert feet to target unit
    /// </summary>
    private static double FromFeet(double value, LengthUnit targetUnit)
    {
        return targetUnit switch
        {
            LengthUnit.Feet => value,
            LengthUnit.Inch => value * 12,
            LengthUnit.Yards => value / 3,
            LengthUnit.Centimeters => value * 30.48,
            _ => throw new ArgumentException("Unsupported Unit")
        };
    }

    /// <summary>
    /// UC6: Add two length quantities
    /// Result will be in the unit of the first operand
    /// </summary>
    public QuantityLength Add(QuantityLength other)
    {
        if (other == null)
            throw new ArgumentException("Second operand cannot be null");

        // convert both to feet
        double first = this.ToFeet();
        double second = other.ToFeet();

        // add
        double sumInFeet = first + second;

        // convert result back to first unit
        double resultValue = FromFeet(sumInFeet, this.Unit);

        return new QuantityLength(resultValue, this.Unit);
    }

    /// <summary>
    /// Equality comparison based on feet conversion
    /// </summary>
    public override bool Equals(object? obj)
    {
        if (obj is not QuantityLength other)
            return false;

        return Math.Abs(ToFeet() - other.ToFeet()) < 0.0001;
    }

    public override int GetHashCode()
    {
        return ToFeet().GetHashCode();
    }

    public override string ToString()
    {
        return $"{Value} {Unit}";
    }
}