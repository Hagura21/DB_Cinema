using Microsoft.EntityFrameworkCore;

namespace Cinema
{
    public sealed class CinemaContext : DbContext
    {
        public CinemaContext(DbContextOptions<CinemaContext> options)
        : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=cinema;Username=postgres;Password=yourpassword");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>()
        .HasMany(a => a.Films)   // Актер может быть в нескольких фильмах
        .WithMany(f => f.Cast)   // Фильм может содержать несколько актеров
        .UsingEntity(j => j.ToTable("ActorFilms")); // Дополнительная таблица для связи

            // Связь между фильмом и директором
            modelBuilder.Entity<Film>()
        .HasOne(f => f.Director)
        .WithMany(d => d.Films)
        .HasForeignKey(f => f.DirectorId)
        .OnDelete(DeleteBehavior.Cascade);

            // Остальная конфигурация
            modelBuilder.Entity<Session>()
                .HasOne(s => s.Hall)
                .WithMany(h => h.Sessions)
                .HasForeignKey(s => s.HallId);

            modelBuilder.Entity<Session>()
                .HasOne(s => s.Film)
                .WithMany()
                .HasForeignKey(s => s.FilmId);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Session)
                .WithMany()
                .HasForeignKey(t => t.SessionId);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.User)
                .WithMany()
                .HasForeignKey(t => t.UserId);
        }

    }
}
