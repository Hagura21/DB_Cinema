namespace Cinema
{
    using Staff;

    /// Класс Зал
    public sealed class Hall : IEquatable<Hall>
    {
        /// Инициализирует новый экземпляр класса <see cref="Hall"/>.
        /// <param name="name"> Имя зала.</param>
        /// <param name="capacity"> Вместимость зала. </param>
        public Hall(
            string name,
            int capacity)
        {
            this.HallId = Guid.NewGuid();
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.Capacity = capacity;
        }

        public Guid HallId { get; }
        public string Name { get; }
        public int Capacity { get; }

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

        public override bool Equals(object? obj)
        {
            return this.Equals(obj as Hall);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Name, this.Capacity);
        }

        public override string ToString() =>
            $"{this.Name} (Capacity: {this.Capacity})";
    }
}
