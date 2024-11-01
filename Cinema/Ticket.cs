﻿// <copyright file="Ticket.cs" company="Кирюшин Н.А.">
// Copyright (c) Кирюшин Н.А.. All rights reserved.
// </copyright>

namespace Cinema
{
    using Staff;

    /// <summary>
    /// Класс Билет.
    /// </summary>
    public sealed class Ticket : IEquatable<Ticket>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Ticket"/>.
        /// </summary>
        /// <param name="session"> Сеанс.</param>
        /// <param name="user"> Клиент.</param>
        /// <param name="seat"> Место.</param>
        /// <param name="cost"> Стоимость билета.</param>
        /// <exception cref="ArgumentNullException">
        /// Если какое-либо значение <see langword="null"/>.
        /// </exception>
        public Ticket(
            Session session,
            User user,
            string seat,
            decimal cost)
        {
            this.TicketId = Guid.NewGuid();
            this.Session = session ?? throw new ArgumentNullException(nameof(session));
            this.User = user ?? throw new ArgumentNullException(nameof(user));
            this.Seat = seat ?? throw new ArgumentNullException(nameof(seat));
            this.Cost = cost > 0 ? cost : throw new ArgumentNullException(nameof(cost));
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid TicketId { get; }

        /// <summary>
        /// Сеанс.
        /// </summary>
        public Session Session { get; }

        /// <summary>
        /// Клиент.
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Место.
        /// </summary>
        public string Seat { get; }

        /// <summary>
        /// Стоимость билета.
        /// </summary>
        public decimal Cost { get; }

        /// <inheritdoc />
        public bool Equals(Ticket? other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Session.Equals(other.Session) &&
                   this.User.Equals(other.User) &&
                   this.Seat == other.Seat &&
                   this.Cost == other.Cost;
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return this.Equals(obj as Ticket);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Session, this.User, this.Seat, this.Cost);
        }

        /// <inheritdoc cref="object.ToString()"/>
        public override string ToString() =>
            $"Ticket for {this.User.UserName} - sear: {this.Seat}, Cost: {this.Cost:C}";
    }
}
