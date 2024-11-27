// <copyright file="Actor.cs" company="Кирюшин Н.А.">
// Copyright (c) Кирюшин Н.А.. All rights reserved.
// </copyright>

namespace Cinema
{
    using System;
    using System.Collections.Generic;

    public class Actor
    {
        public Guid ActorId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }

        // Навигационное свойство для связи с фильмами (многие ко многим)
        public ISet<Film> Films { get; set; } = new HashSet<Film>();

        // Конструктор
        public Actor(string name)
        {
            Name = name;
        }
    }
}

