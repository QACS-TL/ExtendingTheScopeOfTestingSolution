using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSelector.Models
{
    public class Movie
    {

        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<decimal> ShowTimes { get; set; }
        public override string ToString()
        {
            //string times = string.Join(",", ShowTimes);
            List<string> showTimes = new List<string>();
            foreach(decimal showTime in ShowTimes)
            {
                int hoursPart = (int)showTime;
                decimal dPart = showTime % 1.0m;
                int minutes = (int)(dPart * 60);
                showTimes.Add(string.Join(",", hoursPart + ":" + minutes.ToString("D2")));
            }
            string times = string.Join(", ", showTimes);
            return $"{Title} is showing at {times}";
        }
    }
}
