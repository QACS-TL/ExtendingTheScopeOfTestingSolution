using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSelector.Models
{
    //Genuine MovieContext that (would) hook up to database
    public class MoviesContext: IMoviesContext
    {
        List<Movie> movies = new List<Movie>();

        public MoviesContext()
        {
            movies.Add(new Movie {
                MovieId = 1,
                Title = "ET",
                Overview = "Phone Home",
                ReleaseDate = DateTime.Now.AddDays(+1),
                ShowTimes = new List<decimal>(){ 9, 16, 17 }
            });
            movies.Add(new Movie
            {
                MovieId = 2,
                Title = "Jaws",
                Overview = "It's Crunch Time",
                ReleaseDate = DateTime.Now.AddDays(+1),
                ShowTimes = new List<decimal>() { 9.5m, 17, 20 }
            });
            movies.Add(new Movie
            {
                MovieId = 3,
                Title = "Ghost Busters",
                Overview = "Who You Gonna Call?",
                ReleaseDate = DateTime.Now.AddDays(+1),
                ShowTimes = new List<decimal>() { 17, 20 }
            });
            movies.Add(new Movie
            {
                MovieId = 3,
                Title = "Ghost Busters",
                Overview = "Who You Gonna Call?",
                ReleaseDate = DateTime.Now.AddDays(+2),
                ShowTimes = new List<decimal>() { 18, 21 }
            });
            movies.Add(new Movie
            {
                MovieId = 4,
                Title = "The Railway Children",
                Overview = "Watch out for the buffers!",
                ReleaseDate = DateTime.Now.AddDays(+1),
                ShowTimes = new List<decimal>() { 9, 11, 14.25m }
            });
            movies.Add(new Movie
            {
                MovieId = 4,
                Title = "The Railway Children",
                Overview = "Watch out for the buffers!",
                ReleaseDate = DateTime.Now.AddDays(+3),
                ShowTimes = new List<decimal>() { 9.5m, 11.5m, 14.9m }
            });

        }

        public List<Movie> GetMovies()
        {
            return movies;
        }
    }
}
