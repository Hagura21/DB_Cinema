// <copyright file="Session.cs" company="Кирюшин Н.А.">
// Copyright (c) Кирюшин Н.А.. All rights reserved.
// </copyright>

namespace Cinema
{
    using System;

    /// <summary>
    /// Класс Сессии.
    /// </summary>
    public class Session : IEquatable<Session>
    {
        public Session() { }
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Session"/>.
        /// </summary>
        /// <param name="film">Фильм для сессии.</param>
        /// <param name="hall">Зал, где будет проходить сеанс.</param>
        /// <param name="startTime">Время начала сеанса.</param>
        /// <param name="date">Дата проведения сеанса.</param>
        /// <exception cref="ArgumentNullException">
        /// Если фильм или зал <see langword="null"/>.
        /// </exception>
        public Session(
            Film film,
            Hall hall,
            DateTime startTime,
            DateTime date)
        {
            this.SessionId = Guid.Empty;
            this.Film = film ?? throw new ArgumentNullException(nameof(film), "Фильм не может быть null.");
            this.Hall = hall ?? throw new ArgumentNullException(nameof(hall), "Зал не может быть null.");
            this.StartTime = startTime;
            this.Date = date;
            this.Hall.AddSession(this);
        }

        /// <summary>
        /// Идентификатор сессии.
        /// </summary>
        public Guid SessionId { get; set; }

        /// <summary>
        /// Фильм.
        /// </summary>
        public Film Film { get; }

        /// <summary>
        /// Зал.
        /// </summary>
        public Hall Hall { get; set; }
        // Внешний ключ для Film
        public Guid FilmId { get; set; }

        // Внешний ключ для Hall
        public Guid HallId { get; set; }
        /// <summary>
        /// Время начала.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Дата.
        /// </summary>
        public DateTime Date { get; set; }

        /// <inheritdoc/>
        public bool Equals(Session? other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Film.Equals(other.Film) &&
                   this.Hall.Equals(other.Hall) &&
                   this.StartTime == other.StartTime &&
                   this.Date == other.Date;
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return this.Equals(obj as Session);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Film, this.Hall, this.StartTime, this.Date);
        }

        /// <inheritdoc/>
        public override string ToString() =>
            $"{this.Film.Title} in {this.Hall.Name} - Date: {this.Date:yyyy-MM-dd} {this.StartTime:HH:mm:ss}";
    }
}
