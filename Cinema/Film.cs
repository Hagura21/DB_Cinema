namespace Cinema
{
    using Staff;

    /// Класс Фильмы.
    public sealed class Film : IEquatable<Film>
    {
        /// Инициализирует новый экземпляр класса <see cref="Film"/>.
        /// <param name="title"> Название.</param>
        /// <param name="genre"> Жанр фильма. </param>
        /// <param name="synopsis"> Краткий обзор. </param>
        /// <param name="ageRestriction"> Возрастное ограничение. </param>
        /// <param name="duration"> Продолжительность фильма. </param>
        /// <param name="director"> Режиссер. </param>
        /// <param name="cast"> Актерский состав. </param>
        public Film(
            string title,
            string genre,
            string synopsis,
            int ageRestriction,
            int duration,
            string director,
            string cast)
        {
            this.FilmId = Guid.NewGuid();
            this.Title = title ?? throw new ArgumentNullException(nameof(title));
            this.Genre = genre ?? throw new ArgumentNullException(nameof(genre));
            this.Synopsis = synopsis ?? throw new ArgumentNullException(nameof(synopsis));
            this.AgeRestriction = ageRestriction;
            this.Duration = duration;
            this.Director = director ?? throw new ArgumentNullException(nameof(director));
            this.Cast = cast ?? throw new ArgumentNullException(nameof(cast));
        }

        public Guid FilmId { get; }
        public string Title { get; }
        public string Genre { get; }
        public string Synopsis { get; }
        public int AgeRestriction { get; }
        public int Duration { get; }
        public string Director { get; }
        public string Cast { get; }


        public bool Equals(Film? other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Title == other.Title &&
                   this.Genre == other.Genre &&
                   this.Synopsis == other.Synopsis &&
                   this.AgeRestriction == other.AgeRestriction &&
                   this.Duration == other.Duration &&
                   this.Director == other.Director && 
                   this.Cast == other.Cast;
        }

        public override bool Equals(object? obj)
        {
            return this.Equals(obj as Film);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Title, this.Genre, this.Synopsis, this.AgeRestriction, this.Duration, this.Director, this.Cast);
        }

        public override string ToString() =>
            $"{this.Title} {this.Genre} {this.Synopsis}{this.AgeRestriction} {this.Duration} {this.Director} {this.Cast}";
    }
}
