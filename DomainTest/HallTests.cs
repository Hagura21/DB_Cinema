namespace CinemaTest
{
    using System;
    using System.Collections.Generic;
    using Cinema;
    using NUnit.Framework;

    /// Тесты для класса <see cref="Cinema.Hall"/>.
    [TestFixture]
    public sealed class HallTests
    {
        [TestCase("Main Hall", 100)]
        [TestCase("VIP Hall", 50)]
        public void Ctor_ValidData_DoesNotThrow(string name, int capacity)
        {
            Assert.DoesNotThrow(() => _ = new Hall(name, capacity));
        }

        [TestCase(null, 100)]
        [TestCase("Main Hall", -1)]
        public void Ctor_InvalidData_ThrowsException(string name, int capacity)
        {
            Assert.Throws<ArgumentException>(() => _ = new Hall(name, capacity));
        }

        [Test]
        public void Equals_DifferentHalls_NotEqual()
        {
            var hall1 = new Hall("Hall1", 100);
            var hall2 = new Hall("Hall2", 100);

            Assert.That(hall1, Is.Not.EqualTo(hall2));
        }

        [Test]
        public void Equals_SimilarHalls_Success()
        {
            var hall1 = new Hall("Hall", 100);
            var hall2 = new Hall("Hall", 100);

            Assert.That(hall1, Is.EqualTo(hall2));
        }
    }
}
