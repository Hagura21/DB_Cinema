﻿// <copyright file="Actor.cs" company="Кирюшин Н.А.">
// Copyright (c) Кирюшин Н.А.. All rights reserved.
// </copyright>

namespace Cinema
{
    public sealed class Actor : Person
    {
        public Actor(string name) : base(name)
        {
            this.Films = new HashSet<Film>();
        }

        public ISet<Film> Films { get; }

        public void AddFilm(Film film)
        {
            if (film == null)
            {
                throw new ArgumentNullException(nameof(film));
            }

            this.Films.Add(film);
        }
    }
}