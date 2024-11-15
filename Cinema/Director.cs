// <copyright file="Director.cs" company="Кирюшин Н.А.">
// Copyright (c) Кирюшин Н.А.. All rights reserved.
// </copyright>

namespace Cinema
{
    public sealed class Director : Person
    {
        public Director(string name) : base(name)
        {
        }

        public void AddFilm(Film film)
        {
            if (film is null)
            {
                throw new ArgumentNullException(nameof(film));
            }

            film.Director = this;
            this.Films.Add(film);
        }
    }
}
