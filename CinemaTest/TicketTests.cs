// <copyright file="TicketTests.cs" company="Кирюшин Н.А.">
// Copyright (c) Кирюшин Н.А.. All rights reserved.
// </copyright>

namespace CinemaTest
{
    using System;
    using System.Collections.Generic;
    using Cinema;
    using NUnit.Framework;

    /// <summary>
    /// Тесты для класса <see cref="Cinema.Ticket"/>.
    /// </summary>
    [TestFixture]
    public sealed class TicketTests
    {
        [Test]
        public void Ctor_ValidData_DoesNotThrow()
        {
            // Создание пользователя
            var user = new User("username", "email@example.com", "password");

            // Создание директора
            var director = new Director("Christopher Nolan");

            // Создание актеров
            var actor1 = new Actor("Leonardo DiCaprio");
            var actor2 = new Actor("Joseph Gordon-Levitt");
            var actors = new HashSet<Actor> { actor1, actor2 };

            // Создание фильма
            var film = new Film("Inception", "Sci-Fi", "A mind-bending thriller.", 13, 148, director, actors);

            // Создание зала
            var hall = new Hall("Main Hall", 100);

            // Дата и время сеанса
            var date = new DateTime(2023, 10, 31);
            var startTime = new DateTime(2023, 10, 31, 19, 0, 0);

            // Создание сессии
            var session = new Session(film, hall, startTime, date);

            // Проверка, что создание билета не вызывает исключения
            Assert.DoesNotThrow(() => _ = new Ticket(session, user, "5", 15.99m));
        }

        [Test]
        public void Equals_DifferentTickets_NotEqual()
        {
            var user = new User("username", "email@example.com", "password");

            var director = new Director("Christopher Nolan");

            var actor1 = new Actor("Leonardo DiCaprio");
            var actor2 = new Actor("Joseph Gordon-Levitt");
            var actors = new HashSet<Actor> { actor1, actor2 };

            var film = new Film("Inception", "Sci-Fi", "A mind-bending thriller.", 13, 148, director, actors);
            var hall = new Hall("Main Hall", 100);

            var date1 = new DateTime(2022, 11, 21);
            var startTime1 = new DateTime(2022, 11, 21, 19, 0, 0);
            var date2 = new DateTime(2022, 12, 23);
            var startTime2 = new DateTime(2022, 12, 23, 19, 0, 0);

            var session1 = new Session(film, hall, startTime1, date1);
            var session2 = new Session(film, hall, startTime2, date2);

            var ticket1 = new Ticket(session1, user, "5", 15.99m);
            var ticket2 = new Ticket(session2, user, "5", 15.99m);

            // Билеты должны быть разными, так как сеансы отличаются
            Assert.That(ticket1, Is.Not.EqualTo(ticket2));
        }

        [Test]
        public void Equals_SimilarTickets_Success()
        {
            var user = new User("username", "email@example.com", "password");

            var director = new Director("Christopher Nolan");

            var actor1 = new Actor("Leonardo DiCaprio");
            var actor2 = new Actor("Joseph Gordon-Levitt");
            var actors = new HashSet<Actor> { actor1, actor2 };

            var film = new Film("Inception", "Sci-Fi", "A mind-bending thriller.", 13, 148, director, actors);
            var hall = new Hall("Main Hall", 100);

            var date1 = new DateTime(2022, 11, 21);
            var startTime1 = new DateTime(2022, 11, 21, 19, 0, 0);

            var session = new Session(film, hall, startTime1, date1);

            var ticket1 = new Ticket(session, user, "5", 15.99m);
            var ticket2 = new Ticket(session, user, "5", 15.99m);

            // Билеты одинаковые, так как все параметры идентичны
            Assert.That(ticket1, Is.EqualTo(ticket2));
        }
    }
}
