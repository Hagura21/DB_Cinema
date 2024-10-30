namespace Cinema
{
    using Staff;
    using System.Xml.Linq;

    /// Класс Билет.
    public sealed class Ticket : IEquatable<Ticket>
    {
        /// Инициализирует новый экземпляр класса <see cref="Ticket"/>.
        /// <param name="session"> Сеанс.</param>
        /// <param name="user"> Клиент.</param>
        /// <param name="seat"> Место в зале.</param>
        /// <param name="cost"> Цена билета.</param>
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
            this.Cost = cost;
        }

        public Guid TicketId { get; }
        public Session Session { get; }
        public User User { get; }
        public string Seat { get; }
        public decimal Cost { get; }

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

        public override bool Equals(object? obj)
        {
            return this.Equals(obj as Ticket);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Session, this.User, this.Seat, this.Cost);
        }

        public override string ToString() => 
            $"Ticket for {this.User.UserName} - sear: {this.Seat}, Cost: {this.Cost:C}";
    }
}
