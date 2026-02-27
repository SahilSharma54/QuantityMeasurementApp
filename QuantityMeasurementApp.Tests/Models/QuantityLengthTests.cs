using NUnit.Framework;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Tests.Models;

public class QuantityLengthTests
{
    [Test]
    public void FeetToFeet_SameValue_ShouldBeEqual()
    {
        var a = new QuantityLength(1, LengthUnit.Feet);
        var b = new QuantityLength(1, LengthUnit.Feet);

        Assert.IsTrue(a.Equals(b));
    }

    [Test]
    public void InchToInch_SameValue_ShouldBeEqual()
    {
        var a = new QuantityLength(5, LengthUnit.Inch);
        var b = new QuantityLength(5, LengthUnit.Inch);

        Assert.IsTrue(a.Equals(b));
    }

    [Test]
    public void FeetToInch_Equivalent_ShouldBeEqual()
    {
        var feet = new QuantityLength(1, LengthUnit.Feet);
        var inch = new QuantityLength(12, LengthUnit.Inch);

        Assert.IsTrue(feet.Equals(inch));
    }

    [Test]
    public void DifferentValues_ShouldNotBeEqual()
    {
        var a = new QuantityLength(1, LengthUnit.Feet);
        var b = new QuantityLength(2, LengthUnit.Feet);

        Assert.IsFalse(a.Equals(b));
    }

    [Test]
    public void NullComparison_ShouldReturnFalse()
    {
        var a = new QuantityLength(1, LengthUnit.Feet);

        Assert.IsFalse(a.Equals(null));
    }
}