// <copyright file="UserTests.cs" company="Кирюшин Н.А.">
// Copyright (c) Кирюшин Н.А.. All rights reserved.
// </copyright>

namespace CinemaTest
{
    using System;
    using System.Collections.Generic;
    using Cinema;
    using NUnit.Framework;

    /// <summary>
    /// Тесты для класса клиент <see cref="Cinema.User"/>.
    /// </summary>
    [TestFixture]
    public sealed class UserTests
    {
        [TestCase("username", "email@example.com", "password")]
        [TestCase("testUser", "test@example.com", "securePassword")]
        public void Ctor_ValidData_DoesNotThrow(string userName, string email, string password)
        {
            Assert.DoesNotThrow(() => _ = new User(userName, email, password));
        }

        [TestCase(null, "email@example.com", "password")]
        [TestCase("username", null, "password")]
        [TestCase("username", "email@example.com", null)]
        public void Ctor_InvalidData_ThrowsArgumentNullException(string userName, string email, string password)
        {
            Assert.Throws<ArgumentNullException>(() => _ = new User(userName, email, password));
        }

        [Test]
        public void Equals_ValidDataDifferentUserName_NotEqual()
        {
            var user1 = new User("User1", "email@example.com", "password");
            var user2 = new User("User2", "email@example.com", "password");

            Assert.That(user1, Is.Not.EqualTo(user2));
        }

        [Test]
        public void Equals_ValidDataSameUserNameAndEmail_Success()
        {
            var user1 = new User("User", "email@example.com", "password1");
            var user2 = new User("User", "email@example.com", "password2");

            Assert.That(user1, Is.EqualTo(user2));
        }
    }
}
