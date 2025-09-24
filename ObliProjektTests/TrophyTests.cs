namespace ObliProjekt.Tests
{
    [TestClass()]
    public class TrophyTests
    {
        /// <summary>
        /// Tests the creation of a <see cref="Trophy"/> object and verifies that its properties are initialized
        /// correctly.
        /// </summary>
        /// <remarks>This test ensures that the <see cref="Trophy"/> constructor correctly assigns values
        /// to the  <see cref="Trophy.Id"/>, <see cref="Trophy.Competition"/>, and <see cref="Trophy.Year"/>
        /// properties.</remarks>
        [TestMethod()]
        public void TrophyCreateTest()
        {
            Trophy trophy = new Trophy(1, "Champions League", 2020);

            Assert.AreEqual(1, trophy.Id);
            Assert.AreEqual("Champions League", trophy.Competition);
            Assert.AreEqual(2020, trophy.Year);
        }

        /// <summary>
        /// Tests the <see cref="Trophy"/> constructor to ensure it throws an <see cref="ArgumentException"/>  when
        /// provided with an invalid competition name.
        /// </summary>
        /// <remarks>This test verifies that the <see cref="Trophy"/> constructor enforces validation
        /// rules for the  competition name, such as ensuring it is not empty or too short.</remarks>
        [TestMethod()]
        public void TrophyCreateInvalidCompetitionTest()
        {
            Assert.ThrowsException<ArgumentException>(() => new Trophy(1, "", 2020));
            Assert.ThrowsException<ArgumentException>(() => new Trophy(1, "AB", 2020));
        }

        /// <summary>
        /// Tests the creation of a <see cref="Trophy"/> object with valid year values.
        /// </summary>
        /// <remarks>This test verifies that the <see cref="Trophy"/> constructor correctly assigns the
        /// provided year  and that the <see cref="Trophy.Year"/> property returns the expected value.</remarks>
        /// <param name="year">The year to be assigned to the <see cref="Trophy"/> object. Must be a valid year.</param>
        [DataRow(1970)]
        [DataRow(1971)]
        [DataRow(2024)]
        [DataRow(2025)]
        [TestMethod()]
        public void TrophyCreateValidYearTest(int year)
        {
            Trophy trophy = new Trophy(1, "Champions League", year);
            Assert.AreEqual(year, trophy.Year);
        }

        /// <summary>
        /// Tests that creating a <see cref="Trophy"/> with an invalid year throws an <see
        /// cref="ArgumentOutOfRangeException"/>.
        /// </summary>
        /// <remarks>A valid year for a <see cref="Trophy"/> must fall within the acceptable range defined
        /// by the <see cref="Trophy"/> class. This test ensures that the constructor enforces this constraint by
        /// throwing an exception for invalid input.</remarks>
        /// <param name="year">The year to test, which is expected to be outside the valid range for a <see cref="Trophy"/>.</param>
        [DataRow(1800)]
        [DataRow(1969)]
        [DataRow(2026)]
        [DataRow(3000)]
        [TestMethod()]
        public void TrophyCreateInvalidYearTest(int year)
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Trophy(1, "Champions League", year));
        }

        /// <summary>
        /// Tests the <see cref="Trophy.ToString"/> method to ensure it returns the expected string representation of a
        /// trophy.
        /// </summary>
        /// <remarks>This test verifies that the <see cref="Trophy.ToString"/> method correctly formats
        /// the trophy's properties  into a string in the format: "id: {Id}, Competition: {Competition}, Year:
        /// {Year}".</remarks>
        [TestMethod()]
        public void ToStringTest()
        {
            Trophy trophy = new(1, "Champions League", 2020);

            Assert.AreEqual("id: 1, Competition: Champions League, Year: 2020", trophy.ToString());

        }
    }
}