using NUnit.Framework;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Services;

namespace QuantityMeasurementApp.Tests.Services;

/// <summary>
/// UC1 tests → Feet equality using service.
/// </summary>
public class LengthEqualityServiceTests
{
    private LengthEqualityService _service;

    [SetUp]
    public void Setup()
    {
        _service = new LengthEqualityService();
    }

    [Test]
    public void ZeroFeet_ShouldBeEqual()
    {
    var a = LengthMeasure.Feet(0);
    var b = LengthMeasure.Feet(0);

    Assert.That(_service.AreEqual(a, b), Is.True);
    }

    [Test]
    public void SameFeet_ShouldBeEqual()
    {
    var a = LengthMeasure.Feet(1);
    var b = LengthMeasure.Feet(1);

    Assert.That(_service.AreEqual(a, b), Is.True);
    }

    [Test]
    public void DifferentFeet_ShouldNotBeEqual()
    {
    var a = LengthMeasure.Feet(1);
    var b = LengthMeasure.Feet(2);

    Assert.That(_service.AreEqual(a, b), Is.False);
    }
}