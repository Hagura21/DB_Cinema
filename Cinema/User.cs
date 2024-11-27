// <copyright file="User.cs" company="Кирюшин Н.А.">
// Copyright (c) Кирюшин Н.А.. All rights reserved.
// </copyright>

namespace Cinema
{
    using Staff;

    /// <summary>
    /// Класс Автор.
    /// </summary>
    public sealed class User : IEquatable<User>
    {
        public User() { }
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="User"/>.
        /// </summary>
        /// <param name="userName"> Фамилия.</param>
        /// <param name="email"> Имя. </param>
        /// <param name="password"> Отчество. </param>
        /// <exception cref="ArgumentNullException">
        /// Если имя или фамилия <see langword="null"/>.
        /// </exception>
        public User(
            string userName,
            string email,
            string password)
        {
            this.UserId = Guid.Empty;
            this.UserName = userName.TrimOrNull() ?? throw new ArgumentNullException(nameof(userName));
            this.Email = email.TrimOrNull() ?? throw new ArgumentNullException(nameof(email));
            this.Password = password.TrimOrNull() ?? throw new ArgumentNullException(nameof(password));
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        public string Password { get; set; }

        /// <inheritdoc/>
        public bool Equals(User? other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Email == other.Email &&
                   this.UserName == other.UserName;
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return obj is User otherUser && this.Equals(otherUser);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.UserName, this.Email);
        }

        /// <inheritdoc/>
        public override string ToString() =>
            $"{this.UserName} {this.Email} {this.UserName}";
    }
}
