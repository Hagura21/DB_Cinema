// <copyright file="FilmTests.cs" company="Кирюшин Н.А.">
// Copyright (c) Кирюшин Н.А.. All rights reserved.
// </copyright>

namespace CinemaTest
{
    using System;
    using System.Collections.Generic;
    using Cinema;
    using NUnit.Framework;

    /// <summary>
    /// Тесты для класса фильм <see cref="Cinema.Film"/>.
    /// </summary>
    [TestFixture]
    public sealed class FilmTests
    {
        [TestCase("Inception", "Sci-Fi", "A mind-bending thriller.", 13, 148, "Christopher Nolan", new[] { "Leonardo DiCaprio", "Joseph Gordon-Levitt" })]
        [TestCase("The Matrix", "Action", "A hacker discovers the nature of his reality.", 16, 136, "Lana Wachowski, Lilly Wachowski", new[] { "Keanu Reeves", "Laurence Fishburne" })]
        public void Ctor_ValidData_DoesNotThrow(string title, string genre, string synopsis, int ageRestriction, int duration, string director, string[] cast)
        {
            Assert.DoesNotThrow(() => _ = new Film(title, genre, synopsis, ageRestriction, duration, director, new List<string>(cast)));
        }

        [TestCase(null, "Sci-Fi", "A mind-bending thriller.", 13, 148, "Christopher Nolan", new[] { "Leonardo DiCaprio" })]
        [TestCase("Inception", null, "A mind-bending thriller.", 13, 148, "Christopher Nolan", new[] { "Leonardo DiCaprio" })]
        [TestCase("Inception", "Sci-Fi", null, 13, 148, "Christopher Nolan", new[] { "Leonardo DiCaprio" })]
        [TestCase("Inception", "Sci-Fi", "A mind-bending thriller.", 13, -1, "Christopher Nolan", new[] { "Leonardo DiCaprio" })]
        [TestCase("Inception", "Sci-Fi", "A mind-bending thriller.", 13, 148, null, new[] { "Leonardo DiCaprio" })]
        public void Ctor_InvalidData_ThrowsException(string title, string genre, string synopsis, int ageRestriction, int duration, string director, string[] cast)
        {
            if (duration <= 0 || ageRestriction < 0)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => _ = new Film(title, genre, synopsis, ageRestriction, duration, director, new List<string>(cast)));
            }
            else
            {
                Assert.Throws<ArgumentNullException>(() => _ = new Film(title, genre, synopsis, ageRestriction, duration, director, new List<string>(cast)));
            }
        }

        [Test]
        public void Equals_DifferentFilms_NotEqual()
        {
            var film1 = new Film("Inception", "Sci-Fi", "A mind-bending thriller.", 13, 148, "Christopher Nolan", new List<string> { "Leonardo DiCaprio, Joseph Gordon-Levitt" });
            var film2 = new Film("Interstellar", "Sci-Fi", "Exploration of space and time.", 13, 169, "Christopher Nolan", new List<string> { "Matthew McConaughey", "Anne Hathaway" });

            Assert.That(film1, Is.Not.EqualTo(film2));
        }

        [Test]
        public void Equals_SimilarFilms_Success()
        {
            var film1 = new Film("Inception", "Sci-Fi", "A mind-bending thriller.", 13, 148, "Christopher Nolan", new List<string> { "Leonardo DiCaprio", "Joseph Gordon-Levitt" });
            var film2 = new Film("Inception", "Sci-Fi", "A mind-bending thriller.", 13, 148, "Christopher Nolan", new List<string> { "Leonardo DiCaprio", "Joseph Gordon-Levitt" });

            Assert.That(film1, Is.EqualTo(film2));
        }

        [Test]
        public void ToString_ReturnsExpectedString()
        {
            var film = new Film("Inception", "Sci-Fi", "A mind-bending thriller.", 13, 148, "Christopher Nolan", new List<string> { "Leonardo DiCaprio", "Joseph Gordon-Levitt" });
            var expectedString = "Inception (Sci-Fi) - Directed by Christopher Nolan";

            Assert.That(film.ToString(), Is.EqualTo(expectedString));
        }
    }
}
