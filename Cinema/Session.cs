// <copyright file="Session.cs" company="Кирюшин Н.А.">
// Copyright (c) Кирюшин Н.А.. All rights reserved.
// </copyright>

namespace Cinema
{
    using Staff;

    /// <summary>
    /// Класс Сеанс.
    /// </summary>
    public sealed class Session : IEquatable<Session>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Session"/>.
        /// </summary>
        /// <param name="film"> Фильм.</param>
        /// <param name="hall"> Зал. </param>
        /// <param name="startTime"> Начало сеанса. </param>
        /// <param name="date"> Дата сеанса. </param>
        /// <exception cref="ArgumentNullException">
        /// Если какое-либо значение <see langword="null"/>.
        /// </exception>
        public Session(
            Film film,
            Hall hall,
            DateTime startTime,
            DateTime date)
        {
            this.SessionId = Guid.NewGuid();
            this.Film = film ?? throw new ArgumentNullException(nameof(film));
            this.Hall = hall ?? throw new ArgumentNullException(nameof(hall));
            this.StartTime = startTime;
            this.Date = date;
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid SessionId { get; }

        /// <summary>
        /// Фильм.
        /// </summary>
        public Film Film { get; }

        /// <summary>
        /// Зал.
        /// </summary>
        public Hall Hall { get; }

        /// <summary>
        /// Начало сеанса.
        /// </summary>
        public DateTime StartTime { get; }

        /// <summary>
        /// Дата сеанса.
        /// </summary>
        public DateTime Date { get; }

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
            return HashCode.Combine(this.Film, this.Hall, this.StartTime);
        }

        /// <inheritdoc/>
        public override string ToString() =>
            $"{this.Film.Title} in {this.Hall.Name} on {this.Date.ToShortDateString()} at {this.StartTime.ToShortDateString()}";
    }
}
