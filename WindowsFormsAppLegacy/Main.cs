using System;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsAppLegacy.Core.Services;

namespace WindowsFormsAppLegacy;

public partial class Main : Form
{
    readonly private MovieService _movieService;
    private DataGridView _actorGridView;
    private DataGridView _movieGridView;

    public Main()
    {
        InitializeComponent();
        var connectionString = ConfigurationManager.ConnectionStrings["CinemaDb"].ConnectionString;
        _movieService = new MovieService(connectionString);
        LoadMovies();
    }

    private void LoadMovies()
    {
        try
        {
            var movies = _movieService.GetMovies();
            _movieGridView.DataSource = movies;
        }
        catch (Exception ex)
        {
            MessageBox.Show($@"Error loading movies: {ex.Message}", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void MovieGridView_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        // Ensure the click is not on the header row or outside the grid
        if (e.RowIndex < 0 || e.ColumnIndex < 0)
            return;

        // Get the clicked column name
        var columnName = _movieGridView.Columns[e.ColumnIndex].Name;

        // Check if the clicked column is the "Director" column
        if (columnName != "Director")
            return;

        // Get the selected movie's ID
        var movieId = (int)_movieGridView.Rows[e.RowIndex].Cells["Id"].Value;

        // Retrieve the movie details
        var movie = _movieService.GetMovieById(movieId);

        if (movie != null)
            // Populate the actor grid with actor details
            _actorGridView.DataSource = movie.Actors.Select(a => new
            {
                a.Name,
                a.LastName,
                a.Age
            }).ToList();
        else
            MessageBox.Show(@"Movie details not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}