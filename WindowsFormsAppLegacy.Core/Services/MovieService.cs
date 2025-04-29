using System.Collections.Generic;
using System.Linq;
using WindowsFormsAppLegacy.Core.Database;
using WindowsFormsAppLegacy.Core.Models;

namespace WindowsFormsAppLegacy.Core.Services;

public class MovieService
{
    readonly private string _connectionString;

    public MovieService(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<Movie> GetMovies()
    {
        using (var context = new CinemaDbContext(_connectionString))
        {
            return context.Movies.ToList();
        }
    }

    public Movie GetMovieById(int movieId)
    {
        using var context = new CinemaDbContext(_connectionString);
        var movieData = context.Movies
            .Where(m => m.Id == movieId)
            .Select(m => new
            {
                m.Id,
                m.Title,
                m.Description,
                m.ReleaseDate,
                m.Duration,
                m.Genre,
                m.Director,
                Actors = context.ActorsOnMovies
                    .Where(aom => aom.MovieId == m.Id)
                    .Select(aom => new
                    {
                        aom.Actor.Id,
                        aom.Actor.Name,
                        aom.Actor.LastName,
                        aom.Actor.Age
                    }).ToList()
            })
            .FirstOrDefault();

        if (movieData == null)
            return null;

        return new Movie
        {
            Id = movieData.Id,
            Title = movieData.Title,
            Description = movieData.Description,
            ReleaseDate = movieData.ReleaseDate,
            Duration = movieData.Duration,
            Genre = movieData.Genre,
            Director = movieData.Director,
            Actors = movieData.Actors.Select(a => new Actor
            {
                Id = a.Id,
                Name = a.Name,
                LastName = a.LastName,
                Age = a.Age
            }).ToList()
        };
    }

    public List<Movie> GetMoviesByActorId(int actorId)
    {
        using (var context = new CinemaDbContext(_connectionString))
        {
            return context.ActorsOnMovies
                .Where(a => a.ActorId == actorId)
                .Select(a => a.Movie)
                .ToList();
        }
    }
}