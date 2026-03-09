namespace QuantityMeasurementApp.Models;

public class QuantityWeight
{
    public double Value { get; }
    public WeightUnit Unit { get; }

    public QuantityWeight(double value, WeightUnit unit)
    {
        if (!double.IsFinite(value))
            throw new ArgumentException("Invalid weight value");

        Unit = unit;
        Value = value;
    }

    public QuantityWeight ConvertTo(WeightUnit targetUnit)
    {
        double baseValue = Unit.ConvertToBaseUnit(Value);
        double converted = targetUnit.ConvertFromBaseUnit(baseValue);

        return new QuantityWeight(converted, targetUnit);
    }

    public QuantityWeight Add(QuantityWeight other)
    {
        if (other == null)
            throw new ArgumentException("Operand cannot be null");

        double baseSum =
            Unit.ConvertToBaseUnit(Value) +
            other.Unit.ConvertToBaseUnit(other.Value);

        double result = Unit.ConvertFromBaseUnit(baseSum);

        return new QuantityWeight(result, Unit);
    }

    public QuantityWeight Add(QuantityWeight other, WeightUnit targetUnit)
    {
        if (other == null)
            throw new ArgumentException("Operand cannot be null");

        double baseSum =
            Unit.ConvertToBaseUnit(Value) +
            other.Unit.ConvertToBaseUnit(other.Value);

        double result = targetUnit.ConvertFromBaseUnit(baseSum);

        return new QuantityWeight(result, targetUnit);
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != typeof(QuantityWeight))
            return false;

        QuantityWeight other = (QuantityWeight)obj;

        double thisBase = Unit.ConvertToBaseUnit(Value);
        double otherBase = other.Unit.ConvertToBaseUnit(other.Value);

        return Math.Abs(thisBase - otherBase) < 0.000001;
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