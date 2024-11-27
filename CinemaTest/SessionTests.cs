// <copyright file="SessionTests.cs" company="Кирюшин Н.А.">
// Copyright (c) Кирюшин Н.А.. All rights reserved.
// </copyright>

namespace CinemaTest
{
    using System;
    using System.Collections.Generic;
    using Cinema;
    using NUnit.Framework;

    /// <summary>
    /// Тесты для класса <see cref="Cinema.Session"/>.
    /// </summary>
    [TestFixture]
    public sealed class SessionTests
    {
        [Test]
        public void Ctor_ValidData_DoesNotThrow()
        {
            var director = new Director("Christopher Nolan");

            // Создание актеров, а не строк
            var actor1 = new Actor("Leonardo DiCaprio");
            var actor2 = new Actor("Joseph Gordon-Levitt");
            var actors = new HashSet<Actor> { actor1, actor2 };

            var film = new Film("Inception", "Sci-Fi", "A mind-bending thriller.", 13, 148, director, actors);
            var hall = new Hall("Main Hall", 100);
            var date = new DateTime(2023, 10, 31, 19, 0, 0);
            var startTime = new DateTime(2023, 10, 31, 19, 0, 0);

            // Проверка, что создание сессии не вызывает исключений
            Assert.DoesNotThrow(() => _ = new Session(film, hall, date, startTime));
        }

        [Test]
        public void Ctor_InvalidData_ThrowsArgumentNullException()
        {
            var hall = new Hall("Main Hall", 100);
            var date = new DateTime(2023, 10, 31, 19, 0, 0);
            var startTime = new DateTime(2023, 10, 31, 19, 0, 0);

            // Пробуем создать сессию без фильма
            Assert.Throws<ArgumentNullException>(() => _ = new Session(null, hall, date, startTime));
        }

        [Test]
        public void Equals_DifferentSessions_NotEqual()
        {
            var director = new Director("Christopher Nolan");

            // Создание актеров
            var actor1 = new Actor("Leonardo DiCaprio");
            var actor2 = new Actor("Joseph Gordon-Levitt");
            var actors1 = new HashSet<Actor> { actor1, actor2 };

            var actor3 = new Actor("Matthew McConaughey");
            var actor4 = new Actor("Anne Hathaway");
            var actors2 = new HashSet<Actor> { actor3, actor4 };

            var film1 = new Film("Inception", "Sci-Fi", "A mind-bending thriller.", 13, 148, director, actors1);
            var film2 = new Film("Interstellar", "Sci-Fi", "Exploration of space and time.", 13, 169, director, actors2);

            var hall1 = new Hall("Hall1", 100);
            var hall2 = new Hall("Hall2", 100);

            var date = new DateTime(2021, 7, 21, 19, 0, 0);
            var startTime = new DateTime(2022, 10, 31, 19, 0, 0);

            var session1 = new Session(film1, hall1, date, startTime);
            var session2 = new Session(film2, hall2, date, startTime);

            // Сессии должны быть разными, так как фильмы и залы разные
            Assert.That(session1, Is.Not.EqualTo(session2));
        }

        [Test]
        public void Equals_SimilarSessions_Equal()
        {
            var director = new Director("Christopher Nolan");

            // Создание актеров
            var actor1 = new Actor("Leonardo DiCaprio");
            var actor2 = new Actor("Joseph Gordon-Levitt");
            var actors = new HashSet<Actor> { actor1, actor2 };

            var film1 = new Film("Inception", "Sci-Fi", "A mind-bending thriller.", 13, 148, director, actors);
            var hall = new Hall("Hall1", 100);
            var date = new DateTime(2023, 10, 31, 19, 0, 0);
            var startTime = new DateTime(2023, 10, 31, 19, 0, 0);

            var session1 = new Session(film1, hall, date, startTime);
            var session2 = new Session(film1, hall, date, startTime);

            // Сессии должны быть равными, так как все параметры одинаковые
            Assert.That(session1, Is.EqualTo(session2));
        }

        [Test]
        public void ToString_ReturnsExpectedString()
        {
            var director = new Director("Christopher Nolan");
            var actor1 = new Actor("Leonardo DiCaprio");
            var actor2 = new Actor("Joseph Gordon-Levitt");
            var actors = new HashSet<Actor> { actor1, actor2 };

            var film = new Film("Inception", "Sci-Fi", "A mind-bending thriller.", 13, 148, director, actors);
            var hall = new Hall("Main Hall", 100);
            var date = new DateTime(2023, 10, 31, 19, 0, 0);
            var startTime = new DateTime(2023, 10, 31, 19, 0, 0);

            var session = new Session(film, hall, date, startTime);

            var expectedString = "Inception in Main Hall - Date: 2023-10-31 19:00:00";

            Assert.That(session.ToString(), Is.EqualTo(expectedString));
        }
    }
}
