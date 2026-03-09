namespace QuantityMeasurementApp.Models
{
    public enum VolumeUnit
    {
        Litre,
        MilliLitre,
        Gallon
    }

    public static class VolumeUnitExtensions
    {
        public static double ConvertToBaseUnit(this VolumeUnit unit, double value)
        {
            // Base unit: Litre
            return unit switch
            {
                VolumeUnit.Litre => value,
                VolumeUnit.MilliLitre => value / 1000.0,
                VolumeUnit.Gallon => value * 3.78541,
                _ => throw new ArgumentException("Unsupported volume unit")
            };
        }
    }
}