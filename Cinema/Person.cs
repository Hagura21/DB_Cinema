// <copyright file="Person.cs" company="Кирюшин Н.А.">
// Copyright (c) Кирюшин Н.А.. All rights reserved.
// </copyright>

namespace Cinema
{
    using System.Collections.Generic;

    /// <summary>
    /// Абстрактный класс Person, представляющий человека.
    /// </summary>
    public abstract class Person
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Person"/>.
        /// </summary>
        /// <param name="name">Имя.</param>
        public Person(string name)
        {
            this.PersonId = Guid.NewGuid();
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid PersonId { get; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Список фильмов.
        /// </summary>
        public ISet<Film> Films { get; } = new HashSet<Film>();
    }
}