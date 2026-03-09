namespace QuantityMeasurementApp.Models;

/// <summary>
/// Represents a measurable length with value and unit
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

    /// Convert quantity to base unit (Feet)
    private double ToFeet()
    {
        return Unit switch
        {
            LengthUnit.Feet => Value,
            LengthUnit.Inch => Value / 12,
            LengthUnit.Yards => Value * 3,
            LengthUnit.Centimeters => Value / 30.48,
            _ => throw new ArgumentException("Unsupported unit")
        };
    }

    /// Convert feet value to any target unit
    private static double FromFeet(double value, LengthUnit target)
    {
        return target switch
        {
            LengthUnit.Feet => value,
            LengthUnit.Inch => value * 12,
            LengthUnit.Yards => value / 3,
            LengthUnit.Centimeters => value * 30.48,
            _ => throw new ArgumentException("Unsupported unit")
        };
    }

    // ==========================
    // UC6 METHOD
    // ==========================
    /// Adds two quantities and returns result in unit of first operand
    public QuantityLength Add(QuantityLength other)
    {
        if (other == null)
            throw new ArgumentException("Second operand cannot be null");

        double totalFeet = this.ToFeet() + other.ToFeet();
        double result = FromFeet(totalFeet, this.Unit);

        return new QuantityLength(result, this.Unit);
    }

    // ==========================
    // UC7 METHOD (OVERLOADED)
    // ==========================
    /// Adds two quantities and returns result in explicit target unit
    public QuantityLength Add(QuantityLength other, LengthUnit targetUnit)
    {
        if (other == null)
            throw new ArgumentException("Second operand cannot be null");

        double totalFeet = this.ToFeet() + other.ToFeet();

        double result = FromFeet(totalFeet, targetUnit);

        return new QuantityLength(result, targetUnit);
    }

    /// Equality comparison using base unit
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