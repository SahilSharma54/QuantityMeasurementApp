using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Services;

/// <summary>
/// Handles equality comparison for measurements.
/// UC1 → Feet equality.
/// </summary>
public class LengthEqualityService
{
    public bool AreEqual(LengthMeasure first, LengthMeasure second)
    {
        // Null check
        if (first is null || second is null)
            return false;

        // Compare values with tolerance
        bool valueEqual = Math.Abs(first.Value - second.Value) < 0.0001;

        // Compare units
        bool unitEqual = first.Unit == second.Unit;

        return valueEqual && unitEqual;
    }
}