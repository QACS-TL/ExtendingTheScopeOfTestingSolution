using MovieSelector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSelector
{
    public class MovieDecider
    {

        private readonly ITimeService timeService;
        private IMoviesContext moviesContext;

        public MovieDecider(ITimeService timeService, IMoviesContext moviesContext)
        {
            this.timeService = timeService;
            this.moviesContext = moviesContext;
        }

        public MovieDecider()
        {
            this.timeService = new PCTimeService();
            this.moviesContext = new MoviesContext();
        }

        public List<Movie> FilterMovies(int daysFromToday)
        {
            TimeSpan now = timeService.GetTimeOfDay();
            //Get all movies that are running around this time tomorrow
            List<Movie> movies = moviesContext.GetMovies().Where(m => m.ReleaseDate.Date == DateTime.Now.AddDays(daysFromToday).Date).ToList();

            if (now.Hours >= 9 && now.Hours < 12) //morning
                return FilterMoviesOnTime(movies, 9, 12);
            else if (now.Hours >= 12 && now.Hours < 17) //afternoon
                return FilterMoviesOnTime(movies, 12, 17);
            else if (now.Hours >= 17 && now.Hours < 24) //evening
                return FilterMoviesOnTime(movies, 17, 24);
            else //night
                return null;
        }
    
        private static List<Movie> FilterMoviesOnTime(List<Movie> movies, decimal startTime, decimal endTime)
        {
            List<Movie> filteredMovies = new List<Movie>();
            foreach (Movie movie in movies)
            {
                List<decimal> times = new List<decimal>();
                foreach (decimal time in movie.ShowTimes)
                {
                    if (time >= startTime && time < endTime)
                    {
                        times.Add(time);
                    }
                }
                movie.ShowTimes = times;
                if (movie.ShowTimes.Count > 0)
                    filteredMovies.Add(movie);
            }
            return filteredMovies;
        }
    }
}
