using NUnit.Framework;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Tests.Models
{
    public class QuantityTests
    {
        [Test]
        public void GivenFeetAndInch_ShouldReturnEqual()
        {
            QuantityLength feet = new QuantityLength(1, LengthUnit.Feet);
            QuantityLength inch = new QuantityLength(12, LengthUnit.Inch);

            Assert.IsTrue(feet.Equals(inch));
        }

        [Test]
        public void GivenDifferentLengths_ShouldReturnNotEqual()
        {
            QuantityLength feet = new QuantityLength(1, LengthUnit.Feet);
            QuantityLength inch = new QuantityLength(10, LengthUnit.Inch);

            Assert.IsFalse(feet.Equals(inch));
        }
    }
}