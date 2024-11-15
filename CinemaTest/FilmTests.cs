namespace CinemaTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using Cinema;
    using NUnit.Framework;

    /// <summary>
    /// Тесты на класс <see cref="Cinema.Film"/>.
    /// </summary>
    [TestFixture]
    public sealed class FilmTests
    {
        [Test]
        public void Ctor_ValidData_DoesNotThrow()
        {
            // Arrange
            var director = new Director("Christopher Nolan");
            var actors = new HashSet<Actor>
            {
                new Actor("Leonardo DiCaprio"),
                new Actor("Joseph Gordon-Levitt"),
            };

            // Act & Assert
            Assert.DoesNotThrow(() => _ = new Film("Inception", "Sci-Fi", "A mind-bending thriller.", 13, 148, director, actors));
        }

        [Test]
        public void Ctor_InvalidData_ThrowsException()
        {
            Director director = new Director("Christopher Nolan");
            Actor actor1 = new Actor("Leonardo DiCaprio");
            Actor actor2 = new Actor("Joseph Gordon-Levitt");

            Assert.Throws<ArgumentNullException>(() => _ = new Film(null, "Sci-Fi", "A mind-bending thriller.", 13, 148, director, actor1, actor2));
            Assert.Throws<ArgumentNullException>(() => _ = new Film("Inception", null, "A mind-bending thriller.", 13, 148, director, actor1, actor2));
            Assert.Throws<ArgumentNullException>(() => _ = new Film("Inception", "Sci-Fi", null, 13, 148, director, actor1, actor2));
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = new Film("Inception", "Sci-Fi", "A mind-bending thriller.", -1, 148, director, actor1, actor2));
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = new Film("Inception", "Sci-Fi", "A mind-bending thriller.", 13, 0, director, actor1, actor2));
        }

        [Test]
        public void Equals_DifferentFilms_NotEqual()
        {
            // Arrange
            var director = new Director("Christopher Nolan");
            var actors1 = new HashSet<Actor>
            {
                new Actor("Leonardo DiCaprio"),
                new Actor("Joseph Gordon-Levitt"),
            };
            var actors2 = new HashSet<Actor>
            {
                new Actor("Matthew McConaughey"),
                new Actor("Anne Hathaway"),
            };

            var film1 = new Film("Inception", "Sci-Fi", "A mind-bending thriller.", 13, 148, director, actors1);
            var film2 = new Film("Interstellar", "Sci-Fi", "Exploration of space and time.", 13, 169, director, actors2);

            // Assert
            Assert.That(film1, Is.Not.EqualTo(film2));
        }

        [Test]
        public void Equals_SimilarFilms_Success()
        {
            // Arrange
            var director = new Director("Christopher Nolan");
            var actors = new HashSet<Actor>
            {
                new Actor("Leonardo DiCaprio"),
                new Actor("Joseph Gordon-Levitt"),
            };

            var film1 = new Film("Inception", "Sci-Fi", "A mind-bending thriller.", 13, 148, director, actors);
            var film2 = new Film("Inception", "Sci-Fi", "A mind-bending thriller.", 13, 148, director, actors);

            // Assert
            Assert.That(film1, Is.EqualTo(film2));
        }

        [Test]
        public void ToString_ReturnsExpectedString()
        {
            // Arrange
            var director = new Director("Christopher Nolan");
            var actors = new HashSet<Actor>
            {
                new Actor("Leonardo DiCaprio"),
                new Actor("Joseph Gordon-Levitt"),
            };
            var film = new Film("Inception", "Sci-Fi", "A mind-bending thriller.", 13, 148, director, actors);
            var expectedString = "Inception (Sci-Fi) - Directed by Christopher Nolan";

            // Assert
            Assert.That(film.ToString(), Is.EqualTo(expectedString));
        }
    }
}
