namespace Cinema
{
    using Staff;

    /// Класс Сеанс.
    public sealed class Session : IEquatable<Session>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="User"/>.
        /// </summary>
        /// <param name="film"> Фильм.</param>
        /// <param name="hall"> Зал. </param>
        /// <param name="startTime"> Начало сеанса. </param>
        /// <param name="date"> Дата сеанса. </param>
        public Session(
            Film film,
            Hall hall,
            DateTime startTime,
            DateTime date)
        {
            this.SessionId = Guid.NewGuid();
            this.film = film ?? throw new ArgumentNullException(nameof(film));
            this.Hall = hall ?? throw new ArgumentNullException(nameof(hall));
            this.StartTime = startTime;
            this.Date = date;
        }

        public Guid SessionId { get; }
        public Film film { get; }
        public Hall Hall { get; }
        public DateTime StartTime { get; }
        public DateTime Date { get; }

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

            return this.film.Equals(other.film) &&
                this.Hall.Equals(other.Hall) &&
                this.StartTime == other.StartTime &&
                this.Date == other.Date;
        }

        public override bool Equals(object? obj)
        {
            return this.Equals(obj as Session);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.film, this.Hall, this.StartTime);
        }

        public override string ToString() =>
            $"{this.film.Title} in {this.Hall.Name} on {this.Date.ToShortDateString()} at {this.StartTime.ToShortDateString()}";
    }
}
