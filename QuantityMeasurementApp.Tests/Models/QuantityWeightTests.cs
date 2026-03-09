using NUnit.Framework;
using QuantityMeasurementApp.Models;

public class QuantityWeightTests
{
    [Test]
    public void GivenKgAndGram_WhenCompared_ShouldReturnTrue()
    {
        QuantityWeight a = new QuantityWeight(1, WeightUnit.Kilogram);
        QuantityWeight b = new QuantityWeight(1000, WeightUnit.Gram);

        Assert.AreEqual(a, b);
    }

    [Test]
    public void GivenKg_WhenConvertedToGram_ShouldReturn1000()
    {
        QuantityWeight weight = new QuantityWeight(1, WeightUnit.Kilogram);

        QuantityWeight result = weight.ConvertTo(WeightUnit.Gram);

        Assert.AreEqual(1000, result.Value);
    }

    [Test]
    public void GivenKgAndGram_WhenAdded_ShouldReturn2Kg()
    {
        QuantityWeight a = new QuantityWeight(1, WeightUnit.Kilogram);
        QuantityWeight b = new QuantityWeight(1000, WeightUnit.Gram);

        QuantityWeight result = a.Add(b);

        Assert.AreEqual(new QuantityWeight(2, WeightUnit.Kilogram), result);
    }

    [Test]
    public void GivenKgAndGram_WhenAddedWithTargetGram_ShouldReturn2000Gram()
    {
        QuantityWeight a = new QuantityWeight(1, WeightUnit.Kilogram);
        QuantityWeight b = new QuantityWeight(1000, WeightUnit.Gram);

        QuantityWeight result = a.Add(b, WeightUnit.Gram);

        Assert.AreEqual(2000, result.Value);
    }
}