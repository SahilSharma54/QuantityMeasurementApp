namespace QuantityMeasurementApp.Models;

/// <summary>
/// Represents a measurable length.
/// Handles equality, conversion and addition.
/// Conversion logic is delegated to LengthUnit.
/// </summary>
public class QuantityLength
{
    public double Value { get; }
    public LengthUnit Unit { get; }

    public QuantityLength(double value, LengthUnit unit)
    {
        if (!double.IsFinite(value))
            throw new ArgumentException("Invalid numeric value");

        Unit = unit;
        Value = value;
    }

    /// Convert this quantity to another unit
    public QuantityLength ConvertTo(LengthUnit targetUnit)
    {
        double baseValue = Unit.ConvertToBaseUnit(Value);
        double converted = targetUnit.ConvertFromBaseUnit(baseValue);

        return new QuantityLength(converted, targetUnit);
    }

    /// UC6: Add and return result in unit of first operand
    public QuantityLength Add(QuantityLength other)
    {
        if (other == null)
            throw new ArgumentException("Operand cannot be null");

        double baseSum =
            Unit.ConvertToBaseUnit(Value) +
            other.Unit.ConvertToBaseUnit(other.Value);

        double result = Unit.ConvertFromBaseUnit(baseSum);

        return new QuantityLength(result, Unit);
    }

    /// UC7: Add with explicit target unit
    public QuantityLength Add(QuantityLength other, LengthUnit targetUnit)
    {
        if (other == null)
            throw new ArgumentException("Operand cannot be null");

        double baseSum =
            Unit.ConvertToBaseUnit(Value) +
            other.Unit.ConvertToBaseUnit(other.Value);

        double result = targetUnit.ConvertFromBaseUnit(baseSum);

        return new QuantityLength(result, targetUnit);
    }

    /// Equality comparison
    public override bool Equals(object? obj)
    {
        if (obj is not QuantityLength other)
            return false;

        double thisBase = Unit.ConvertToBaseUnit(Value);
        double otherBase = other.Unit.ConvertToBaseUnit(other.Value);

        return Math.Abs(thisBase - otherBase) < 0.0001;
    }

    public override int GetHashCode()
    {
        return Unit.ConvertToBaseUnit(Value).GetHashCode();
    }

    public override string ToString()
    {
        return $"{Value} {Unit}";
    }
}