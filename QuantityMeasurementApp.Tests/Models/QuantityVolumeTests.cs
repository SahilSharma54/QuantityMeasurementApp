using NUnit.Framework;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Tests.Models
{
    public class QuantityVolumeTests
    {
        [Test]
        public void GivenLitre_WhenConvertedToMilliLitre_ShouldReturn1000()
        {
            var litre = new Quantity<VolumeUnit>(1, VolumeUnit.Litre);
            var converted = litre.ConvertTo(VolumeUnit.MilliLitre);
            Assert.That(converted.Value, Is.EqualTo(1000).Within(0.0001));
        }

        [Test]
        public void GivenGallonAndLitre_WhenCompared_ShouldReturnTrue()
        {
            var gallon = new Quantity<VolumeUnit>(1, VolumeUnit.Gallon);
            var litre = new Quantity<VolumeUnit>(3.78541, VolumeUnit.Litre);

            Assert.That(gallon.Equals(litre));
        }

        [Test]
        public void GivenLitreAndMilliLitre_WhenCompared_ShouldReturnTrue()
        {
            var litre = new Quantity<VolumeUnit>(1, VolumeUnit.Litre);
            var ml = new Quantity<VolumeUnit>(1000, VolumeUnit.MilliLitre);

            Assert.That(litre.Equals(ml));
        }

        [Test]
        public void GivenLitreAndMilliLitre_WhenAdded_ShouldReturn2Litre()
        {
            var litre = new Quantity<VolumeUnit>(1, VolumeUnit.Litre);
            var ml = new Quantity<VolumeUnit>(1000, VolumeUnit.MilliLitre);

            var sum = litre.Add(ml);
            Assert.That(sum.ToBaseUnit(), Is.EqualTo(2).Within(0.0001));
        }

        [Test]
        public void GivenLitreAndMilliLitre_WhenAddedWithTargetMilliLitre_ShouldReturn2000()
        {
            var litre = new Quantity<VolumeUnit>(1, VolumeUnit.Litre);
            var ml = new Quantity<VolumeUnit>(1000, VolumeUnit.MilliLitre);

            var sum = litre.Add(ml).ConvertTo(VolumeUnit.MilliLitre);
            Assert.That(sum.Value, Is.EqualTo(2000).Within(0.0001));
        }
    }
}