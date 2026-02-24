namespace QuantityMeasurementApp.Models;

/// <summary>
/// Represents a length measurement with value and unit.
/// Supports Feet (UC1) and Inch (UC2).
/// </summary>
public class LengthMeasure
{
    public double Value { get; }
    public string Unit { get; }

    public LengthMeasure(double value, string unit)
    {
        Value = value;
        Unit = unit;
    }

    // UC1 → Feet factory
    public static LengthMeasure Feet(double value)
    {
        return new LengthMeasure(value, "FEET");
    }

    // UC2 → Inch factory (NEW)
    public static LengthMeasure Inch(double value)
    {
        return new LengthMeasure(value, "INCH");
    }
}