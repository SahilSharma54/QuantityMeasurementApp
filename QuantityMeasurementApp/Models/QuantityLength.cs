namespace QuantityMeasurementApp.Models;

public class QuantityLength
{
    public double Value { get; }
    public LengthUnit Unit { get; }

    public QuantityLength(double value, LengthUnit unit)
    {
        Value = value;
        Unit = unit;
    }

    private double ConvertToFeet()
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

    public static double Convert(double value, LengthUnit from, LengthUnit to)
    {
        double valueInFeet = from switch
        {
            LengthUnit.Feet => value,
            LengthUnit.Inch => value / 12,
            LengthUnit.Yards => value * 3,
            LengthUnit.Centimeters => value / 30.48,
            _ => throw new ArgumentException("Invalid Unit")
        };

        return to switch
        {
            LengthUnit.Feet => valueInFeet,
            LengthUnit.Inch => valueInFeet * 12,
            LengthUnit.Yards => valueInFeet / 3,
            LengthUnit.Centimeters => valueInFeet * 30.48,
            _ => throw new ArgumentException("Invalid Unit")
        };
    }

    public override bool Equals(object? obj)
    {
        if (obj is not QuantityLength other)
            return false;

        return Math.Abs(ConvertToFeet() - other.ConvertToFeet()) < 0.0001;
    }

    public override int GetHashCode()
    {
        return ConvertToFeet().GetHashCode();
    }
}