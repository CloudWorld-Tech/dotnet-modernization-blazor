using Microsoft.AspNetCore.Mvc;
using WebFormsApp.Web.ServiceDefaults;
using WindowsFormsAppLegacy.Core.Services;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddProblemDetails();
builder.Services.AddOpenApi();
builder.Services.AddTransient<MovieService>(_ =>
    new MovieService(builder.Configuration.GetConnectionString("MovieDb")));

var app = builder.Build();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
    app.MapOpenApi();

app.MapDefaultEndpoints();

app.MapGet("/movies/getmoviebyid/id={id:int}",
    ([FromRoute] int id, MovieService movieService) =>
    {
        var movie = movieService.GetMovieById(id);
        return movie is not null ? Results.Ok(movie) : Results.NotFound();
    });

app.MapGet("/movies/getmovies",
    ([FromServices] MovieService movieService) =>
    {
        var movies = movieService.GetMovies();
        return movies is not null ? Results.Ok(movies) : Results.NotFound();
    });

app.Run();