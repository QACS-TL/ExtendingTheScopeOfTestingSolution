using FakeItEasy;
using Xunit;
using MovieSelector;
using MovieSelector.Models;
using MovieSelector;

namespace MovieSelectorTestProject
{
    public class MovieDeciderTests
    {
        List<Movie> movies = new List<Movie>();
        public MovieDeciderTests()
        {
            movies.Add(new Movie
            {
                MovieId = 1,
                Title = "Wall-e",
                Overview = "Watch that waste!",
                ReleaseDate = DateTime.Now.AddDays(+1),
                ShowTimes = new List<decimal>() { 18.334m, 19.167m, 20.75m }
            });
            movies.Add(new Movie
            {
                MovieId = 2,
                Title = "Alien",
                Overview = "In space no one can hear you scream",
                ReleaseDate = DateTime.Now.AddDays(+1),
                ShowTimes = new List<decimal>() { 11, 17.1m, 23.5m }
            });
            movies.Add(new Movie
            {
                MovieId = 3,
                Title = "Gravity",
                Overview = "Stranded in Space!",
                ReleaseDate = DateTime.Now.AddDays(+1),
                ShowTimes = new List<decimal>() { 21, 22 }
            });
            movies.Add(new Movie
            {
                MovieId = 3,
                Title = "Gravity",
                Overview = "Stranded in Space!",
                ReleaseDate = DateTime.Now.AddDays(+2),
                ShowTimes = new List<decimal>() { 20, 22.5m }
            });
            movies.Add(new Movie
            {
                MovieId = 4,
                Title = "Skyfall",
                Overview = "Bond is falling. Again",
                ReleaseDate = DateTime.Now.AddDays(+1),
                ShowTimes = new List<decimal>() { 10.1m, 13, 14, 14.25m }
            });
            movies.Add(new Movie //Same film as previous but on another day
            {
                MovieId = 4,
                Title = "Skyfall",
                Overview = "Bond is falling. Again",
                ReleaseDate = DateTime.Now.AddDays(+2),
                ShowTimes = new List<decimal>() { 11.9833m, 13.5m, 17, 18.25m }
            });
        }

        [Fact]
        public void MorningMoviesTest()
        {
            ITimeService timeService = A.Fake<ITimeService>();
            A.CallTo(() => timeService.GetTimeOfDay()).Returns(new TimeSpan(9, 30, 0));
            IMoviesContext moviesContext = A.Fake<IMoviesContext>();
            A.CallTo(() => moviesContext.GetMovies()).Returns(movies);

            MovieDecider movieDecider = new MovieDecider(timeService, moviesContext);

            List<Movie> filteredMovies = movieDecider.FilterMovies(1);
            Assert.Equal(2, filteredMovies.Count);
            Assert.Equal($"Alien is showing at 11:00", filteredMovies[0].ToString());
            Assert.Equal($"Skyfall is showing at 10:06", filteredMovies[1].ToString());
        }

        [Fact]
        public void AfternoonMoviesTest()
        {
            ITimeService timeService = A.Fake<ITimeService>();
            A.CallTo(() => timeService.GetTimeOfDay()).Returns(new TimeSpan(12, 30, 0));
            IMoviesContext moviesContext = A.Fake<IMoviesContext>();
            A.CallTo(() => moviesContext.GetMovies()).Returns(movies);

            MovieDecider movieDecider = new MovieDecider(timeService, moviesContext);

            List<Movie> filteredMovies = movieDecider.FilterMovies(1);
            Assert.Equal(1, filteredMovies.Count);
            Assert.Equal($"Skyfall is showing at 13:00, 14:00, 14:15", filteredMovies[0].ToString());
        }

        [Fact]
        public void EveningMoviesTest()
        {
            ITimeService timeService = A.Fake<ITimeService>();
            A.CallTo(() => timeService.GetTimeOfDay()).Returns(new TimeSpan(17, 00, 0));
            IMoviesContext moviesContext = A.Fake<IMoviesContext>();
            A.CallTo(() => moviesContext.GetMovies()).Returns(movies);

            MovieDecider movieDecider = new MovieDecider(timeService, moviesContext);

            List<Movie> filteredMovies = movieDecider.FilterMovies(1);
            Assert.Equal(3, filteredMovies.Count);
            Assert.Equal($"Wall-e is showing at 18:20, 19:10, 20:45", filteredMovies[0].ToString());
            Assert.Equal($"Alien is showing at 17:06, 23:30", filteredMovies[1].ToString());
            Assert.Equal($"Gravity is showing at 21:00, 22:00", filteredMovies[2].ToString());
        }

        [Fact]
        public void NightMoviesTest()
        {
            ITimeService timeService = A.Fake<ITimeService>();
            A.CallTo(() => timeService.GetTimeOfDay()).Returns(new TimeSpan(24, 00, 0));
            IMoviesContext moviesContext = A.Fake<IMoviesContext>();
            A.CallTo(() => moviesContext.GetMovies()).Returns(movies);

            MovieDecider movieDecider = new MovieDecider(timeService, moviesContext);

            List<Movie> filteredMovies = movieDecider.FilterMovies(1);
            Assert.True(filteredMovies is null);
        }


        [Fact]
        public void EveningMovies2DaysFromNowTest()
        {
            ITimeService timeService = A.Fake<ITimeService>();
            A.CallTo(() => timeService.GetTimeOfDay()).Returns(new TimeSpan(17, 00, 0));
            IMoviesContext moviesContext = A.Fake<IMoviesContext>();
            A.CallTo(() => moviesContext.GetMovies()).Returns(movies);

            MovieDecider movieDecider = new MovieDecider(timeService, moviesContext);

            List<Movie> filteredMovies = movieDecider.FilterMovies(2);
            Assert.Equal(2, filteredMovies.Count);
            Assert.Equal($"Gravity is showing at 20:00, 22:30", filteredMovies[0].ToString());
            Assert.Equal($"Skyfall is showing at 17:00, 18:15", filteredMovies[1].ToString());
        }

    }
}
