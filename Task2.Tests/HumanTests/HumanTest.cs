using Task2.Humans;
using Xunit;

namespace Task2.Tests.HumanTests
{
    public class HumanTest
    {
        [Theory]
        [InlineData("Pavel", "Belarus", "Gomel", true)]
        [InlineData("Misha", "Russia", "Moscow", false)]
        public void Equal(string name, string city, string country, bool areEqual)
        {
            // arrange
            var actual = new Human(name, city, country);
            var expected = new Human();

            //act
            if (areEqual)
            {
                expected = new Human("Pavel", "Belarus", "Gomel");
            }

            //assert
            if (areEqual)
            {
                Assert.Equal(expected, actual);
            }
            else
            {
                Assert.NotEqual(expected, actual);
            }
        }

        [Theory]
        [InlineData("Pavel", "Belarus", "Gomel", true)]
        [InlineData("Misha", "Russia", "Moscow", false)]
        public void GetHeshCode(string name, string city, string country, bool areEqual)
        {
            // arrange
            var actual = new Human(name, city, country);
            var expected = new Human();

            //act
            if (areEqual)
            {
                expected = new Human("Pavel", "Belarus", "Gomel");
            }

            //assert
            if (areEqual)
            {
                Assert.Equal(expected.GetHashCode(), actual.GetHashCode());
            }
            else
            {
                Assert.NotEqual(expected.GetHashCode(), actual.GetHashCode());
            }
        }

        [Theory]
        [InlineData("Pavel", "Belarus", "Gomel", true)]
        [InlineData("Misha", "Russia", "Moscow", false)]
        public void ToStringTest(string name, string city, string country, bool areEqual)
        {
            // arrange
            var actual = new Human(name, city, country);
            var expected = new Human();

            //act
            if (areEqual)
            {
                expected = new Human("Pavel", "Belarus", "Gomel");
            }

            //assert
            if (areEqual)
            {
                Assert.Equal(expected.ToString(), actual.ToString());
            }
            else
            {
                Assert.NotEqual(expected.ToString(), actual.ToString());
            }
        }
    }
}
