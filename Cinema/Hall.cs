// <copyright file="Hall.cs" company="Кирюшин Н.А.">
// Copyright (c) Кирюшин Н.А.. All rights reserved.
// </copyright>

namespace Cinema
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Класс Зал.
    /// </summary>
    public sealed class Hall : IEquatable<Hall>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Hall"/>.
        /// </summary>
        /// <param name="name">Название зала.</param>
        /// <param name="capacity">Вместимость зала.</param>
        /// <exception cref="ArgumentNullException">
        /// Если название зала <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Если емкость зала меньше или равна нулю.
        /// </exception>
        public Hall(
            string name,
            int capacity)
        {
            this.HallId = Guid.Empty;
            this.Name = name ?? throw new ArgumentNullException(nameof(name), "Название зала не может быть null.");
            this.Capacity = capacity > 0 ? capacity : throw new ArgumentException("Вместимость зала должна быть положительной.", nameof(capacity));
            this.sessions = new List<Session>();
        }

        /// <summary>
        /// Идентификатор зала.
        /// </summary>
        public Guid HallId { get; }

        /// <summary>
        /// Название зала.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Вместимость зала.
        /// </summary>
        public int Capacity { get; }

        /// <summary>
        /// Список сессий, назначенных на зал.
        /// </summary>
        private List<Session> sessions;

        /// <summary>
        /// Возвращает доступ к сессиям зала.
        /// </summary>
        public List<Session> Sessions => this.sessions;


        /// <summary>
        /// Добавляет новую сессию в зал.
        /// </summary>
        /// <param name="session">Сессия для добавления.</param>
        /// <exception cref="ArgumentNullException">Если сессия <see langword="null"/>.</exception>
        public void AddSession(Session session)
        {
            if (session is null)
            {
                throw new ArgumentNullException(nameof(session), "Сессия не может быть null.");
            }

            if (!this.sessions.Contains(session))
            {
                this.sessions.Add(session);
                session.Hall = this;
            }
        }

        /// <summary>
        /// Удаляет сессию из зала.
        /// </summary>
        /// <param name="session">Сессия для удаления.</param>
        /// <returns><see langword="true" , если сессия была удалена <see langword="false".</returns>
        public bool RemoveSession(Session session)
        {
            if (session is null)
            {
                throw new ArgumentNullException(nameof(session), "Сессия не может быть null.");
            }

            return this.sessions.Remove(session);
        }

        /// <inheritdoc/>
        public bool Equals(Hall other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Name == other.Name && this.Capacity == other.Capacity;
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return this.Equals(obj as Hall);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Name, this.Capacity);
        }

        /// <inheritdoc/>
        public override string ToString() =>
            $"{this.Name} (Capasity: {this.Capacity})";
    }
}
