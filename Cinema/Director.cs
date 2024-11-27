namespace Cinema
{
    using System;
    using System.Collections.Generic;

    public class Director
    {
        // Идентификатор режиссера (первичный ключ)
        public Guid DirectorId { get; set; }

        // Имя режиссера
        public string Name { get; set; }

        // Фильмы, снятые режиссером
        public ISet<Film> Films { get; set; }

        public Director(string name)
        {
            this.DirectorId = Guid.NewGuid();
            this.Name = name;
            this.Films = new HashSet<Film>();
        }
    }
}
