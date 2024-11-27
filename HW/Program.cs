using Cinema;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Demo
{
    class Program
    {

        static void Main(string[] args)
        {
            // Настройка параметров подключения через DbContextOptions
            var options = new DbContextOptionsBuilder<CinemaContext>();
            options.UseNpgsql("Host=localhost;Port=5432;Database=cinema;Username=postgres;Password=amofun96");  // Подключение к базе данных
            
            // Создание экземпляра контекста с параметрами конфигурации
            using (var context = new CinemaContext(options.Options))
            {
                try
                {
                    // Пример создания актеров и фильма
                    var director = new Director("Director Name");
                    var actors = new HashSet<Actor> { new Actor("Actor Name 1"), new Actor("Actor Name 2") };

                    // Создание экземпляра Film с 5 параметрами
                    var film = new Film("Film Title", "Action", "Synopsis of the film", 18, 120);

                    // Установка навигационных свойств после создания
                    film.Director = director;
                    film.Cast = actors;

                    // Теперь вы можете использовать объект film


                    // Попробуем сохранить фильм в базу данных
                    context.Films.Add(film);
                    context.SaveChanges();

                    Console.WriteLine("Фильм добавлен успешно!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
        }
    }
}
