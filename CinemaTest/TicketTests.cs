// <copyright file="TicketTests.cs" company="Кирюшин Н.А.">
// Copyright (c) Кирюшин Н.А.. All rights reserved.
// </copyright>

namespace CinemaTest
{
    using System;
    using System.Collections.Generic;
    using Cinema;
    using NUnit.Framework;
    using static System.Runtime.InteropServices.JavaScript.JSType;

    /// <summary>
    /// Тесты для класса билет <see cref="Cinema.Ticket"/>.
    /// </summary>
    [TestFixture]
    public sealed class TicketTests
    {
        [Test]
        public void Ctor_ValidData_DoesNotThrow()
        {
            var user = new User("username", "email@example.com", "password");
            var film = new Film("Inception", "Sci-Fi", "A mind-bending thriller.", 13, 148, "Christopher Nolan", new List<string> { "Leonardo DiCaprio, Joseph Gordon-Levitt" });
            var hall = new Hall("Hall", 100);
            var date = new DateTime(2023, 10, 31);
            var startTime = new DateTime(19, 0);

            var session = new Session(film, hall, startTime, date);

            Assert.DoesNotThrow(() => _ = new Ticket(session, user, "5", 15.99m));
        }

        [Test]
        public void Equals_DifferentTickets_NotEqual()
        {
            var user = new User("username", "email@example.com", "password");
            var film = new Film("Inception", "Sci-Fi", "A mind-bending thriller.", 13, 148, "Christopher Nolan", new List<string> { "Leonardo DiCaprio, Joseph Gordon-Levitt" });
            var hall = new Hall("Hall", 100);
            var date1 = new DateTime(2022, 11, 21);
            var startTime1 = new DateTime(19, 0);
            var date2 = new DateTime(2022, 12, 23);
            var startTime2 = new DateTime(19, 0);

            var session1 = new Session(film, hall, startTime1, date1);
            var session2 = new Session(film, hall, startTime2, date2);

            var ticket1 = new Ticket(session1, user, "5", 15.99m);
            var ticket2 = new Ticket(session2, user, "5", 15.99m);

            Assert.That(ticket1, Is.Not.EqualTo(ticket2));
        }

        [Test]
        public void Equals_SimilarTickets_Success()
        {
            var user = new User("username", "email@example.com", "password");
            var film = new Film("Inception", "Sci-Fi", "A mind-bending thriller.", 13, 148, "Christopher Nolan", new List<string> { "Leonardo DiCaprio, Joseph Gordon-Levitt" });
            var hall = new Hall("Hall", 100);
            var date1 = new DateTime(2022, 11, 21);
            var startTime1 = new DateTime(19, 0);

            var session = new Session(film, hall, startTime1, date1);

            var ticket1 = new Ticket(session, user, "5", 15.99m);
            var ticket2 = new Ticket(session, user, "5", 15.99m);

            Assert.That(ticket1, Is.EqualTo(ticket2));
        }
    }
}
