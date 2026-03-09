using NUnit.Framework;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Services;

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

    [Test]
    public void Yard_To_Feet_ShouldBeEqual()
    {
        var yard = new QuantityLength(1, LengthUnit.Yards);
        var feet = new QuantityLength(3, LengthUnit.Feet);

        Assert.IsTrue(yard.Equals(feet));
    }

    [Test]
    public void Yard_To_Inch_ShouldBeEqual()
    {
        var yard = new QuantityLength(1, LengthUnit.Yards);
        var inch = new QuantityLength(36, LengthUnit.Inch);

        Assert.IsTrue(yard.Equals(inch));
    }

    [Test]
    public void Cm_To_Inch_ShouldBeEqual()
    {
        var cm = new QuantityLength(1, LengthUnit.Centimeters);
        var inch = new QuantityLength(0.393701, LengthUnit.Inch);

        Assert.IsTrue(cm.Equals(inch));
    }

    [Test]
public void Given1Feet_WhenConvertedToInch_ShouldReturn12()
{
    double result = LengthConverter.Convert(1, LengthUnit.Feet, LengthUnit.Inch);
    Assert.AreEqual(12, result);
}

[Test]
public void Given3Feet_WhenConvertedToYard_ShouldReturn1()
{
    double result = LengthConverter.Convert(3, LengthUnit.Feet, LengthUnit.Yards);
    Assert.AreEqual(1, result);
}

[Test]
public void Given1Inch_WhenConvertedToCentimeter_ShouldReturn2Point54()
{
    double result = LengthConverter.Convert(1, LengthUnit.Inch, LengthUnit.Centimeters);
    Assert.AreEqual(2.54, result, 0.01);
}

[Test]
public void GivenFeetAndFeet_WhenAdded_ShouldReturnFeet()
{
    QuantityLength a = new QuantityLength(1, LengthUnit.Feet);
    QuantityLength b = new QuantityLength(2, LengthUnit.Feet);

    QuantityLength result = a.Add(b);

    Assert.AreEqual(new QuantityLength(3, LengthUnit.Feet), result);
}

[Test]
public void GivenFeetAndInch_WhenAdded_ShouldReturnFeet()
{
    QuantityLength a = new QuantityLength(1, LengthUnit.Feet);
    QuantityLength b = new QuantityLength(12, LengthUnit.Inch);

    QuantityLength result = a.Add(b);

    Assert.AreEqual(new QuantityLength(2, LengthUnit.Feet), result);
}

[Test]
public void GivenInchAndFeet_WhenAdded_ShouldReturnInch()
{
    QuantityLength a = new QuantityLength(12, LengthUnit.Inch);
    QuantityLength b = new QuantityLength(1, LengthUnit.Feet);

    QuantityLength result = a.Add(b);

    Assert.AreEqual(new QuantityLength(24, LengthUnit.Inch), result);
}

[Test]
public void GivenYardsAndFeet_WhenAdded_ShouldReturnYards()
{
    QuantityLength a = new QuantityLength(1, LengthUnit.Yards);
    QuantityLength b = new QuantityLength(3, LengthUnit.Feet);

    QuantityLength result = a.Add(b);

    Assert.AreEqual(new QuantityLength(2, LengthUnit.Yards), result);
}

[Test]
public void GivenCentimetersAndInch_WhenAdded_ShouldReturnCentimeters()
{
    QuantityLength a = new QuantityLength(2.54, LengthUnit.Centimeters);
    QuantityLength b = new QuantityLength(1, LengthUnit.Inch);

    QuantityLength result = a.Add(b);

    Assert.AreEqual(5.08, result.Value, 0.01);
}

[Test]
public void GivenFeetAndInch_WhenTargetFeet_ShouldReturnFeet()
{
    QuantityLength a = new QuantityLength(1, LengthUnit.Feet);
    QuantityLength b = new QuantityLength(12, LengthUnit.Inch);

    QuantityLength result = a.Add(b, LengthUnit.Feet);

    Assert.AreEqual(new QuantityLength(2, LengthUnit.Feet), result);
}

[Test]
public void GivenFeetAndInch_WhenTargetInch_ShouldReturnInch()
{
    QuantityLength a = new QuantityLength(1, LengthUnit.Feet);
    QuantityLength b = new QuantityLength(12, LengthUnit.Inch);

    QuantityLength result = a.Add(b, LengthUnit.Inch);

    Assert.AreEqual(new QuantityLength(24, LengthUnit.Inch), result);
}

[Test]
public void GivenFeetAndInch_WhenTargetYards_ShouldReturnYards()
{
    QuantityLength a = new QuantityLength(1, LengthUnit.Feet);
    QuantityLength b = new QuantityLength(12, LengthUnit.Inch);

    QuantityLength result = a.Add(b, LengthUnit.Yards);

    Assert.AreEqual(0.667, result.Value, 0.01);
}

[Test]
public void GivenInchAndInch_WhenTargetCentimeters_ShouldReturnCentimeters()
{
    QuantityLength a = new QuantityLength(1, LengthUnit.Inch);
    QuantityLength b = new QuantityLength(1, LengthUnit.Inch);

    QuantityLength result = a.Add(b, LengthUnit.Centimeters);

    Assert.AreEqual(5.08, result.Value, 0.01);
}

}