using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSelector
{
    public class TimeOfDayDecider
    {
        private readonly ITimeService timeService;

        public TimeOfDayDecider(ITimeService timeService)
        {
            this.timeService = timeService;
        }

        public TimeOfDayDecider()
        {
            this.timeService = new PCTimeService();
        }

        public string GetTimeOfDay()
        {
            TimeSpan now = timeService.GetTimeOfDay();

            if (now.Hours >= 9 && now.Hours < 12) //morning
                return "morning";
            else if (now.Hours >= 12 && now.Hours < 17) //afternoon
                return "afternoon";
            else if (now.Hours >= 17 && now.Hours < 24) //evening
                return "evening";
            else //night
                return "night";
        }
    }
}
