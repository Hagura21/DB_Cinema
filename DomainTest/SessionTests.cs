namespace CinemaTest
{
    using System;
    using System.Collections.Generic;
    using Cinema;
    using NUnit.Framework;

    /// Тесты для класса <see cref="Cinema.Session"/>.
    [TestFixture]
    public sealed class SessionTests
    {
        [Test]
        public void Ctor_ValidData_DoesNotThrow()
        {
            var film = new Film("Inception", "Sci-Fi", "A mind-bending thriller.", 13, 148, "Christopher Nolan", "Leonardo DiCaprio, Joseph Gordon-Levitt");
            var hall = new Hall("Hall", 100);
            var date = new DateTime(2023, 10, 31, 19, 0, 0);
            var startTime = new DateTime(2024, 10, 31, 19, 0, 0);

            Assert.DoesNotThrow(() => _ = new Session(film, hall, date, startTime));
        }

        [Test]
        public void Equals_DifferentSessions_NotEqual()
        {
            var film = new Film("Inception", "Sci-Fi", "A mind-bending thriller.", 13, 148, "Christopher Nolan", "Leonardo DiCaprio, Joseph Gordon-Levitt");
            var hall1 = new Hall("Hall1", 100);
            var hall2 = new Hall("Hall2", 100);
            var date = new DateTime(2021, 7, 21, 19, 0, 0);
            var startTime = new DateTime(2022, 10, 31, 19, 0, 0);

            var session1 = new Session(film, hall1, date, startTime);
            var session2 = new Session(film, hall2, date, startTime);

            Assert.That(session1, Is.Not.EqualTo(session2));
        }
    }
}
