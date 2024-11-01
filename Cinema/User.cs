// <copyright file="User.cs" company="Кирюшин Н.А.">
// Copyright (c) Кирюшин Н.А.. All rights reserved.
// </copyright>

namespace Cinema
{
    using Staff;

    /// <summary>
    /// Класс Клиент.
    /// </summary>
    public sealed class User : IEquatable<User>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="User"/>.
        /// </summary>
        /// <param name="userName"> Имя клиента.</param>
        /// <param name="email"> Почта. </param>
        /// <param name="password"> Пароль. </param>
        /// <exception cref="ArgumentNullException">
        /// Если имя, почта или пароль <see langword="null"/>.
        /// </exception>
        public User(
            string userName,
            string email,
            string password)
        {
            this.UserId = Guid.NewGuid();
            this.UserName = userName.TrimOrNull() ?? throw new ArgumentNullException(nameof(userName));
            this.Email = email.TrimOrNull() ?? throw new ArgumentNullException(nameof(email));
            this.Password = password.TrimOrNull() ?? throw new ArgumentNullException(nameof(password));
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid UserId { get; }

        /// <summary>
        /// Имя клиента.
        /// </summary>
        public string UserName { get; }

        /// <summary>
        /// Почта.
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Пароль.
        /// </summary>
        public string Password { get; }

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
