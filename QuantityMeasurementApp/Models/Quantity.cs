using QuantityMeasurementApp.Interfaces;

namespace QuantityMeasurementApp.Models;

public class Quantity<U> where U : Enum
{
    public double Value { get; }
    public U Unit { get; }

    public Quantity(double value, U unit)
    {
        if (!double.IsFinite(value))
            throw new ArgumentException("Invalid value");

        Unit = unit ?? throw new ArgumentException("Unit cannot be null");
        Value = value;
    }

    private double ToBaseUnit()
    {
        dynamic u = Unit;
        return u.ConvertToBaseUnit(Value);
    }

    public Quantity<U> ConvertTo(U targetUnit)
    {
        dynamic source = Unit;
        dynamic target = targetUnit;

        double baseValue = source.ConvertToBaseUnit(Value);
        double converted = target.ConvertFromBaseUnit(baseValue);

        return new Quantity<U>(Math.Round(converted, 2), targetUnit);
    }

    public Quantity<U> Add(Quantity<U> other)
    {
        double sum = this.ToBaseUnit() + other.ToBaseUnit();

        dynamic unit = Unit;
        double result = unit.ConvertFromBaseUnit(sum);

        return new Quantity<U>(Math.Round(result, 2), Unit);
    }

    public Quantity<U> Add(Quantity<U> other, U targetUnit)
    {
        double sum = this.ToBaseUnit() + other.ToBaseUnit();

        dynamic target = targetUnit;
        double result = target.ConvertFromBaseUnit(sum);

        return new Quantity<U>(Math.Round(result, 2), targetUnit);
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != this.GetType())
            return false;

        Quantity<U> other = (Quantity<U>)obj;

        return Math.Abs(this.ToBaseUnit() - other.ToBaseUnit()) < 0.0001;
    }

    public override int GetHashCode()
    {
        return ToBaseUnit().GetHashCode();
    }

    public override string ToString()
    {
        return $"{Value} {Unit}";
    }
}