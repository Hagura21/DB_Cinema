namespace Cinema
{
    using Staff;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Класс Фильм.
    /// </summary>
    public sealed class Film : IEquatable<Film>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Film"/>.
        /// </summary>
        /// <param name="title">Название.</param>
        /// <param name="genre">Жанр фильма.</param>
        /// <param name="synopsis">Краткий обзор.</param>
        /// <param name="ageRestriction">Возрастное ограничение.</param>
        /// <param name="duration">Продолжительность фильма.</param>
        /// <param name="director">Режиссер.</param>
        /// <param name="cast">Актерский состав.</param>
        /// <exception cref="ArgumentNullException">Если какое-либо значение <see langword="null"/>.</exception>
        public Film(
            string title,
            string genre,
            string synopsis,
            int ageRestriction,
            int duration,
            Director director,
            ISet<Actor> cast)
        {
            this.FilmId = Guid.Empty;
            this.Title = title ?? throw new ArgumentNullException(nameof(title));
            this.Genre = genre ?? throw new ArgumentNullException(nameof(genre));
            this.Synopsis = synopsis ?? throw new ArgumentNullException(nameof(synopsis));
            this.AgeRestriction = ageRestriction > 0 ? ageRestriction : throw new ArgumentOutOfRangeException(nameof(ageRestriction), "Age restriction cannot be negative.");
            this.Duration = duration > 0 ? duration : throw new ArgumentOutOfRangeException(nameof(duration), "Duration must be positive.");
            this.Director = director ?? throw new ArgumentNullException(nameof(director));
            this.Cast = cast ?? throw new ArgumentNullException(nameof(cast));

            // Add this film to director and actor film lists
            this.Director.Films.Add(this);
            foreach (var actor in cast)
            {
                actor.Films.Add(this);
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Film"/> с массивом актеров.
        /// </summary>
        /// <param name="title">Название.</param>
        /// <param name="genre">Жанр фильма.</param>
        /// <param name="synopsis">Краткий обзор.</param>
        /// <param name="ageRestriction">Возрастное ограничение.</param>
        /// <param name="duration">Продолжительность фильма.</param>
        /// <param name="director">Режиссер.</param>
        /// <param name="actors">Актеры.</param>
        public Film(
            string title,
            string genre,
            string synopsis,
            int ageRestriction,
            int duration,
            Director director,
            params Actor[] actors)
            : this(title, genre, synopsis, ageRestriction, duration, director, new HashSet<Actor>(actors))
        {
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid FilmId { get; }

        /// <summary>
        /// Название.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Жанр фильма.
        /// </summary>
        public string Genre { get; }

        /// <summary>
        /// Краткий обзор.
        /// </summary>
        public string Synopsis { get; }

        /// <summary>
        /// Возрастное ограничение.
        /// </summary>
        public int AgeRestriction { get; }

        /// <summary>
        /// Продолжительность фильма.
        /// </summary>
        public int Duration { get; }

        /// <summary>
        /// Режиссер.
        /// </summary>
        public Director Director { get; set; }

        /// <summary>
        /// Актерский состав.
        /// </summary>
        public ISet<Actor> Cast { get; }

        /// <inheritdoc/>
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
                   this.Director.Equals(other.Director);
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return this.Equals(obj as Film);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Title, this.Genre, this.Director);
        }

        /// <inheritdoc/>
        public override string ToString() =>
            $"{this.Title} ({this.Genre}) - Directed by {this.Director.Name}";
    }
}
