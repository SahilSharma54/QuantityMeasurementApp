namespace QuantityMeasurementApp.Models;

/// <summary>
/// Represents a length measurement.
/// Only stores value and unit.
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

    public static LengthMeasure Feet(double value)
    {
        return new LengthMeasure(value, "FEET");
    }
}