using NUnit.Framework;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Services;

namespace QuantityMeasurementApp.Tests.Services;

public class LengthEqualityServiceTests
{
    private LengthEqualityService _service;

    [SetUp]
    public void Setup()
    {
        _service = new LengthEqualityService();
    }

    // ===== UC1 tests (existing) =====

    [Test]
    public void SameFeet_ShouldBeEqual()
    {
        var a = LengthMeasure.Feet(1);
        var b = LengthMeasure.Feet(1);

        Assert.IsTrue(_service.AreEqual(a, b));
    }

    // ===== UC2 tests (NEW) =====

    [Test]
    public void SameInch_ShouldBeEqual()
    {
        var a = LengthMeasure.Inch(5);
        var b = LengthMeasure.Inch(5);

        Assert.IsTrue(_service.AreEqual(a, b));
    }

    [Test]
    public void DifferentInch_ShouldNotBeEqual()
    {
        var a = LengthMeasure.Inch(2);
        var b = LengthMeasure.Inch(7);

        Assert.IsFalse(_service.AreEqual(a, b));
    }

    [Test]
    public void FeetAndInch_ShouldNotBeEqual()
    {
        var feet = LengthMeasure.Feet(1);
        var inch = LengthMeasure.Inch(1);

        Assert.IsFalse(_service.AreEqual(feet, inch));
    }
}