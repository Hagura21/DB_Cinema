namespace Cinema
{
    using Staff;

     /// Класс Клиент.
    public sealed class User : IEquatable<User>
    {
        /// Инициализирует новый экземпляр класса <see cref="User"/>.
        /// <param name="userName"> Имя клиента.</param>
        /// <param name="email"> Электронная почта. </param>
        /// <param name="password"> Пароль. </param>
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


        public Guid UserId { get; }
        public string UserName { get; }
        public string Email { get; }
        public string Password { get; }

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
                   this.UserName == other.UserName &&
                   this.Password == other.Password;

        }

        public override bool Equals(object? obj)
        {
            return this.Equals(obj as User);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.UserName, this.Email, this.Password);
        }

        public override string ToString() =>
            $"{this.UserName} {this.Email} {this.Password}";
    }
}
