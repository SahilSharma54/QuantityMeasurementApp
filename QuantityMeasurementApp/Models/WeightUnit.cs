namespace QuantityMeasurementApp.Models;

public enum WeightUnit
{
    Kilogram,
    Gram,
    Pound
}

public static class WeightUnitExtensions
{
    private const double GramFactor = 0.001;
    private const double PoundFactor = 0.453592;

    public static double ConvertToBaseUnit(this WeightUnit unit, double value)
    {
        return unit switch
        {
            WeightUnit.Kilogram => value,
            WeightUnit.Gram => value * GramFactor,
            WeightUnit.Pound => value * PoundFactor,
            _ => throw new ArgumentException("Unsupported weight unit")
        };
    }

    public static double ConvertFromBaseUnit(this WeightUnit unit, double baseValue)
    {
        return unit switch
        {
            WeightUnit.Kilogram => baseValue,
            WeightUnit.Gram => baseValue / GramFactor,
            WeightUnit.Pound => baseValue / PoundFactor,
            _ => throw new ArgumentException("Unsupported weight unit")
        };
    }
}