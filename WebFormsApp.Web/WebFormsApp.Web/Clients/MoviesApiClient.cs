using WindowsFormsAppLegacy.Core.Models;

namespace WebFormsApp.Web.Clients;

public class MoviesApiClient(HttpClient httpClient)
{
    public async Task<Movie?> GetMovieById(int id)
    {
        var response = httpClient.GetAsync($"movies/getmoviebyid/id={id}").Result;
        if (!response.IsSuccessStatusCode)
            throw new Exception("Error fetching movie data");

        var movie = await response.Content.ReadFromJsonAsync<Movie>();
        return movie;
    }

    public async Task<List<Movie>?> GetMovies()
    {
        var response = httpClient.GetAsync("movies/getmovies").Result;
        if (!response.IsSuccessStatusCode)
            throw new Exception("Error fetching movies data");

        var movies = await response.Content.ReadFromJsonAsync<List<Movie>>();
        return movies;
    }
}