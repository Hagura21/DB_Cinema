using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Cinema
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options)
            : base(options)
        {
        }

        // Таблицы
        public DbSet<Actor> Actors { get; set; }

        public DbSet<Director> Directors { get; set; }

        public DbSet<Film> Films { get; set; }

        public DbSet<Hall> Halls { get; set; }

        public DbSet<Session> Sessions { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Загрузка конфигурации из appsettings.json
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Настройка маппинга для таблиц
            modelBuilder.Entity<Actor>()
                .HasMany(a => a.Films)
                .WithMany(f => f.Cast);

            modelBuilder.Entity<Director>()
                .HasMany(d => d.Films)
                .WithOne(f => f.Director);

            modelBuilder.Entity<Film>()
                .HasMany(f => f.Cast)
                .WithMany(a => a.Films);

            modelBuilder.Entity<Hall>()
                .HasMany(h => h.Sessions)
                .WithOne(s => s.Hall);

            modelBuilder.Entity<Session>()
                .HasOne(s => s.Film)
                .WithMany();

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Session)
                .WithMany();

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.User)
                .WithMany();
        }
    }
}
