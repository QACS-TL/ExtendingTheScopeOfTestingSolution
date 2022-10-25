using MovieSelector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSelector
{
    class Program
    {
        static void Main(string[] args)
        {
            MovieDecider movieDecider = new MovieDecider();
            TimeOfDayDecider timeOfDayDecider = new TimeOfDayDecider();

            List<Movie> movies = movieDecider.FilterMovies(1);
            string timeOfDay = timeOfDayDecider.GetTimeOfDay();


            if (movies.Count > 0)
            {
                Console.WriteLine($"The following movies are available to watch this {timeOfDay}:");
                movies.ForEach(m => Console.WriteLine(m));
            }
            else
                Console.WriteLine($"There are no movies are available to watch this {timeOfDay}");

            Console.WriteLine("Hit any key to exit...");
            Console.Read();
        }
    }
}
