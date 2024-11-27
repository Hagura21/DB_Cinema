using Cinema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class CinemaContextFactory : IDesignTimeDbContextFactory<CinemaContext>
{
    public CinemaContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CinemaContext>();

        // Замените строку подключения на вашу реальную строку
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=cinema;Username=postgres;Password=amofun96");

        return new CinemaContext(optionsBuilder.Options);
    }
}
