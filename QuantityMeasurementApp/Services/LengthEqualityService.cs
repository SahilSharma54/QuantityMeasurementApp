using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Services;

/// <summary>
/// Handles equality comparison for length measurements.
/// Supports Feet (UC1) and Inch (UC2).
/// </summary>
public class LengthEqualityService
{
    public bool AreEqual(LengthMeasure first, LengthMeasure second)
    {
        // Null safety
        if (first is null || second is null)
            return false;

        // Units must match (UC2 rule)
        if (first.Unit != second.Unit)
            return false;

        // Value comparison using tolerance
        double difference = Math.Abs(first.Value - second.Value);
        return difference < 0.0001;
    }
}