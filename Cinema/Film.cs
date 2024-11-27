namespace Cinema
{
    using System;
    using System.Collections.Generic;

    public sealed class Film : IEquatable<Film>
    {
        public Guid FilmId { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Synopsis { get; set; }
        public int AgeRestriction { get; set; }
        public int Duration { get; set; }
        public Guid DirectorId { get; set; }  // Foreign key для связи с Director

        // Навигационное свойство
        public Director Director { get; set; }   // Навигация на Director
        public ISet<Actor> Cast { get; set; } = new HashSet<Actor>();  // Навигация на Actors

        // Конструктор с 5 параметрами (без навигационных свойств)
        public Film(string title, string genre, string synopsis, int ageRestriction, int duration)
        {
            Title = title;
            Genre = genre;
            Synopsis = synopsis;
            AgeRestriction = ageRestriction;
            Duration = duration;
        }
        public bool Equals(Film? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return this.Title == other.Title && this.Genre == other.Genre && this.Director.Equals(other.Director);
        }

        public override bool Equals(object? obj)
        {
            return this.Equals(obj as Film);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Title, this.Genre, this.Director);
        }

        public override string ToString()
        {
            return $"{this.Title} ({this.Genre}) - Directed by {this.Director.Name}";
        }
    }
}
