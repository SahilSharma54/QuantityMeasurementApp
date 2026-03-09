namespace QuantityMeasurementApp.Models
{
    public class Quantity<TUnit> where TUnit : struct, Enum
    {
        public double Value { get; }
        public TUnit Unit { get; }

        public Quantity(double value, TUnit unit)
        {
            Value = value;
            Unit = unit;
        }

        // Convert quantity to base unit value
        public double ToBaseUnit()
        {
            if (typeof(TUnit) == typeof(VolumeUnit))
                return ((VolumeUnit)(object)Unit).ConvertToBaseUnit(Value);
            throw new NotImplementedException("Conversion for this unit type is not implemented");
        }

        // Convert to another unit
        public Quantity<TUnit> ConvertTo(TUnit targetUnit)
        {
            double baseValue = ToBaseUnit();

            double convertedValue = targetUnit switch
            {
                VolumeUnit v when typeof(TUnit) == typeof(VolumeUnit) => baseValue / ((VolumeUnit)(object)targetUnit).ConvertToBaseUnit(1),
                _ => throw new NotImplementedException("Conversion for this unit type is not implemented")
            };

            return new Quantity<TUnit>(convertedValue, targetUnit);
        }

        public Quantity<TUnit> Add(Quantity<TUnit> other)
        {
            double sumBase = this.ToBaseUnit() + other.ToBaseUnit();
            return new Quantity<TUnit>(sumBase, this.Unit);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Quantity<TUnit> other)
                return Math.Abs(this.ToBaseUnit() - other.ToBaseUnit()) < 0.0001;
            return false;
        }

        public override int GetHashCode()
        {
            return ToBaseUnit().GetHashCode();
        }
    }
}