// <copyright file="HallTests.cs" company="Кирюшин Н.А.">
// Copyright (c) Кирюшин Н.А.. All rights reserved.
// </copyright>

namespace CinemaTest
{
    using System;
    using System.Collections.Generic;
    using Cinema;
    using NUnit.Framework;

    /// <summary>
    /// Тесты для класса <see cref="Cinema.Hall"/>.
    /// </summary>
    [TestFixture]
    public sealed class HallTests
    {
        [TestCase("Main Hall", 100)]
        [TestCase("VIP Hall", 50)]
        public void Ctor_ValidData_DoesNotThrow(string name, int capacity)
        {
            Assert.DoesNotThrow(() => _ = new Hall(name, capacity));
        }

        [TestCase("Main Hall", -1)]
        [TestCase("VIP Hall", 0)]
        public void Ctor_InvalidCapacity_ThrowsArgumentException(string name, int capacity)
        {
            var ex = Assert.Throws<ArgumentException>(() => _ = new Hall(name, capacity));
            Assert.That(ex.ParamName, Is.EqualTo("capacity"));
            Assert.That(ex.Message, Does.StartWith("Вместимость зала должна быть положительной."));
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
