using Task1.Students;
using Xunit;

namespace Task1.Tests
{
    /// <summary>
    /// The class tests the student.
    /// </summary>
    public class StudentsTest
    {
        /// <summary>
        /// The method checks the equivalence of two objects.
        /// </summary>
        /// <param name="name">Student name.</param>
        /// <param name="testName">Test name.</param>
        /// <param name="testDate">Date of the test.</param>
        /// <param name="assessment">Test assessment.</param>
        /// <param name="areEquale">Turns the case on or off.</param>
        [Theory]
        [InlineData("Pavel", "MMA", "18.02.2020", 10, true)]
        [InlineData("Maxim", "MMA", "18.02.2020", 8, false)]
        public void Equal(string name, string testName, string testDate, int assessment,bool areEquale)
        {
            // arrange
            var actual = new Student("Pavel", "MMA", "18.02.2020", 10);
            var expected = new Student(name, testName, testDate, assessment);

            //assert
            if (areEquale)
            {
                Assert.True(expected.Equals(actual));
            }else
            {
                Assert.False(expected.Equals(actual));
            }
        }

        /// <summary>
        /// The method checks the receipt of the hash code.
        /// </summary>
        /// <param name="name">Student name.</param>
        /// <param name="testName">Test name.</param>
        /// <param name="testDate">Date of the test.</param>
        /// <param name="assessment">Test assessment.</param>
        /// <param name="areEquale">Turns the case on or off.</param>
        [Theory]
        [InlineData("Pavel", "MMA", "18.02.2020", 10, true)]
        [InlineData("Maxim", "MMA", "18.02.2020", 8, false)]
        public void GetHashCodeTest(string name, string testName, string testDate, int assessment, bool areEquale)
        {
            // arrange
            var actual = new Student("Pavel", "MMA", "18.02.2020", 10);
            var expected = new Student(name, testName, testDate, assessment);

            //assert
            if (areEquale)
            {
                Assert.Equal(expected.GetHashCode(), actual.GetHashCode());
            }
            else
            {
                Assert.NotEqual(expected.GetHashCode(), actual.GetHashCode());
            }
        }
    }
}