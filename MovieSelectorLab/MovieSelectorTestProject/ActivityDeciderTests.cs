using FakeItEasy;
using Xunit;
using MovieSelector;

namespace MovieSelectorTestProject
{
    public class ActivityDeciderTests
    {
        [Fact]
        public void MorningTest()
        {
            ITimeService timeService = A.Fake<ITimeService>();
            A.CallTo(() => timeService.GetTimeOfDay()).Returns(new TimeSpan(9, 30, 0));

            TimeOfDayDecider timeOfDayDecider = new TimeOfDayDecider(timeService);

            string timeOfDay = timeOfDayDecider.GetTimeOfDay();
            Assert.Equal("morning", timeOfDay);
        }

        [Fact]
        public void AfternoonTest()
        {
            ITimeService timeService = A.Fake<ITimeService>();
            A.CallTo(() => timeService.GetTimeOfDay()).Returns(new TimeSpan(12, 30, 0));

            TimeOfDayDecider timeOfDayDecider = new TimeOfDayDecider(timeService);

            string timeOfDay = timeOfDayDecider.GetTimeOfDay();
            Assert.Equal("afternoon", timeOfDay);
        }

        [Fact]
        public void EveningTest()
        {
            ITimeService timeService = A.Fake<ITimeService>();
            A.CallTo(() => timeService.GetTimeOfDay()).Returns(new TimeSpan(17, 30, 0));

            TimeOfDayDecider timeOfDayDecider = new TimeOfDayDecider(timeService);

            string timeOfDay = timeOfDayDecider.GetTimeOfDay();
            Assert.Equal("evening", timeOfDay);
        }

        [Fact]
        public void NightTest()
        {
            ITimeService timeService = A.Fake<ITimeService>();
            A.CallTo(() => timeService.GetTimeOfDay()).Returns(new TimeSpan(24, 30, 0));

            TimeOfDayDecider timeOfDayDecider = new TimeOfDayDecider(timeService);

            string timeOfDay = timeOfDayDecider.GetTimeOfDay();
            Assert.Equal("night", timeOfDay);
        }

        [Fact]
        public void MorningMorningNightBoundaryTest()
        {
            ITimeService timeService = A.Fake<ITimeService>();
            A.CallTo(() => timeService.GetTimeOfDay()).Returns(new TimeSpan(9, 0, 0));

            TimeOfDayDecider timeOfDayDecider = new TimeOfDayDecider(timeService);

            string timeOfDay = timeOfDayDecider.GetTimeOfDay();
            Assert.Equal("morning", timeOfDay);
        }

        [Fact]
        public void NightMorningNightBoundaryTest()
        {
            ITimeService timeService = A.Fake<ITimeService>();
            A.CallTo(() => timeService.GetTimeOfDay()).Returns(new TimeSpan(8, 59, 59));

            TimeOfDayDecider timeOfDayDecider = new TimeOfDayDecider(timeService);

            string timeOfDay = timeOfDayDecider.GetTimeOfDay();
            Assert.Equal("night", timeOfDay);
        }

        [Fact]
        public void AfternoonAfternoonMorningBoundaryTest()
        {
            ITimeService timeService = A.Fake<ITimeService>();
            A.CallTo(() => timeService.GetTimeOfDay()).Returns(new TimeSpan(12, 0, 0));

            TimeOfDayDecider timeOfDayDecider = new TimeOfDayDecider(timeService);

            string timeOfDay = timeOfDayDecider.GetTimeOfDay();
            Assert.Equal("afternoon", timeOfDay);
        }

        [Fact]
        public void MorningAfternoonMorningBoundaryTest()
        {
            ITimeService timeService = A.Fake<ITimeService>();
            A.CallTo(() => timeService.GetTimeOfDay()).Returns(new TimeSpan(11, 59, 59));

            TimeOfDayDecider timeOfDayDecider = new TimeOfDayDecider(timeService);

            string timeOfDay = timeOfDayDecider.GetTimeOfDay();
            Assert.Equal("morning", timeOfDay);
        }


        [Fact]
        public void EveningEveningAfternoonBoundaryTest()
        {
            ITimeService timeService = A.Fake<ITimeService>();
            A.CallTo(() => timeService.GetTimeOfDay()).Returns(new TimeSpan(17, 0, 0));

            TimeOfDayDecider timeOfDayDecider = new TimeOfDayDecider(timeService);

            string timeOfDay = timeOfDayDecider.GetTimeOfDay();
            Assert.Equal("evening", timeOfDay);
        }

        [Fact]
        public void AfternoonEveningAfternoonBoundaryTest()
        {
            ITimeService timeService = A.Fake<ITimeService>();
            A.CallTo(() => timeService.GetTimeOfDay()).Returns(new TimeSpan(16, 59, 59));

            TimeOfDayDecider timeOfDayDecider = new TimeOfDayDecider(timeService);

            string timeOfDay = timeOfDayDecider.GetTimeOfDay();
            Assert.Equal("afternoon", timeOfDay);
        }

        [Fact]
        public void NightNightEveningBoundaryTest()
        {
            ITimeService timeService = A.Fake<ITimeService>();
            A.CallTo(() => timeService.GetTimeOfDay()).Returns(new TimeSpan(24, 0, 0));

            TimeOfDayDecider timeOfDayDecider = new TimeOfDayDecider(timeService);

            string timeOfDay = timeOfDayDecider.GetTimeOfDay();
            Assert.Equal("night", timeOfDay);
        }

        [Fact]
        public void EveningNightEveningBoundaryTest()
        {
            ITimeService timeService = A.Fake<ITimeService>();
            A.CallTo(() => timeService.GetTimeOfDay()).Returns(new TimeSpan(23, 59, 59));

            TimeOfDayDecider timeOfDayDecider = new TimeOfDayDecider(timeService);

            string timeOfDay = timeOfDayDecider.GetTimeOfDay();
            Assert.Equal("evening", timeOfDay);
        }
    }
}