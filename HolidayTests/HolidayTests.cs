#region

using System;
using Lib;
using NUnit.Framework;

#endregion

namespace HolidayTests
{
    [TestFixture]
    public class HolidayTests
    {
        private HolidayForTest _holiday;

        [SetUp]
        public void SetUp()
        {
            _holiday = new HolidayForTest();
        }

        [Test]
        public void today_is_xmas()
        {
            GivenToday(12, 25);
            ResponseShouldBe("Merry Xmas");
        }

        [Test]
        public void today_is_xmas_when_12_24()
        {
            GivenToday(12, 24);
            ResponseShouldBe("Merry Xmas");
        }

        [Test]
        public void today_is_not_xmas()
        {
            GivenToday(11, 25);
            ResponseShouldBe("Today is not Xmas");
        }

        private void ResponseShouldBe(string expected)
        {
            Assert.AreEqual(expected, _holiday.SayHello());
        }

        private void GivenToday(int month, int day)
        {
            _holiday.Today = new DateTime(2020, month, day);
        }
    }

    public class HolidayForTest : Holiday
    {
        private DateTime _today;

        public DateTime Today
        {
            set => _today = value;
        }

        protected override DateTime GetToday()
        {
            return _today;
        }
    }
}