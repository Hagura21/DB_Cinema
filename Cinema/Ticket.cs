using Cinema;

public sealed class Ticket : IEquatable<Ticket>
{
    public Ticket() { }
    public Ticket(
        Session session,
        User user,
        string seat,
        decimal cost)
    {
        this.TicketId = Guid.Empty;
        this.Session = session ?? throw new ArgumentNullException(nameof(session));
        this.User = user ?? throw new ArgumentNullException(nameof(user));
        this.Seat = seat ?? throw new ArgumentNullException(nameof(seat));
        this.Cost = cost > 0 ? cost : throw new ArgumentOutOfRangeException(nameof(cost));
    }

    public Guid TicketId { get; set; }

    // Убедитесь, что в классе Ticket нет двух свойств для User.
    public User User { get; set; } // Навигационное свойство для User.

    // Добавьте внешний ключ, если нужно.
    public Guid UserId { get; set; }
    public Guid SessionId { get; set; }
    public Session Session { get; set; }
    public string Seat { get; set; }
    public decimal Cost { get; set; }

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
        $"Ticket for {this.User.UserName} - seat: {this.Seat}, Cost: {this.Cost:C}";
}
