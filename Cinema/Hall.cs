// <copyright file="Hall.cs" company="Кирюшин Н.А.">
// Copyright (c) Кирюшин Н.А.. All rights reserved.
// </copyright>

namespace Cinema
{
    using Staff;

    /// <summary>
    /// Класс Зал.
    /// </summary>
    public sealed class Hall : IEquatable<Hall>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Hall"/>.
        /// </summary>
        /// <param name="name"> Название зала.</param>
        /// <param name="capacity"> Вместимость. </param>
        /// <exception cref="ArgumentNullException">
        /// Если название или вместимость <see langword="null"/>.
        /// </exception>
        public Hall(
            string name,
            int capacity)
        {
            this.HallId = Guid.NewGuid();
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.Capacity = capacity > 0 ? capacity : throw new ArgumentNullException("Capacity cannot be negative.", nameof(capacity));
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid HallId { get; }

        /// <summary>
        /// Название зала.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Вместимость.
        /// </summary>
        public int Capacity { get; }

        /// <inheritdoc/>
        public bool Equals(Hall? other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Name == other.Name &&
                   this.Capacity == other.Capacity;
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
            $"{this.Name} (Capscity: {this.Capacity})";
    }
}
