using System.Data.Entity;
using WindowsFormsAppLegacy.Core.Models;

namespace WindowsFormsAppLegacy.Core.Database;

public class CinemaDbContext : DbContext
{
    public CinemaDbContext(string connectionString) : base(connectionString)
    {
    }

    public DbSet<Actor> Actors { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<ActorsOnMovies> ActorsOnMovies { get; set; }
}