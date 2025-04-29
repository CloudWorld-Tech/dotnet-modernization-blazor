namespace WindowsFormsAppLegacy.Core.Models;

public class ActorsOnMovies
{
    public ActorsOnMovies(int actorId, int movieId)
    {
        ActorId = actorId;
        MovieId = movieId;
    }

    public ActorsOnMovies()
    {
    }

    public int Id { get; set; }
    public int ActorId { get; set; }
    public int MovieId { get; set; }
    public Actor Actor { get; set; }
    public Movie Movie { get; set; }
}