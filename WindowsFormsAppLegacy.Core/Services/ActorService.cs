using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using WindowsFormsAppLegacy.Core.Database;
using WindowsFormsAppLegacy.Core.Models;

namespace WindowsFormsAppLegacy.Core.Services;

public class ActorService
{
    public List<Actor> GetActors()
    {
        var connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        using (var context = new CinemaDbContext(connectionString))
        {
            return context.Actors.ToList();
        }
    }

    public List<Actor> GetActorsByMovieId(int movieId)
    {
        var connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        using (var context = new CinemaDbContext(connectionString))
        {
            return context.ActorsOnMovies
                .Where(a => a.MovieId == movieId)
                .Select(a => a.Actor)
                .ToList();
        }
    }

    public Actor GetActorById(int actorId)
    {
        var connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        using (var context = new CinemaDbContext(connectionString))
        {
            return context.Actors.FirstOrDefault(a => a.Id == actorId);
        }
    }
}