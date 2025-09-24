namespace ObliProjekt.Tests
{
    [TestClass()]
    public class TrophiesRepositoryTests
    {
        private TrophiesRepository trophiesRepository;
        [TestInitialize]
        public void init()
        {
            trophiesRepository = new TrophiesRepository();
        }

        [TestMethod()]
        public void TrophiesRepositoryTest()
        {
            // Act & Assert
            Assert.AreEqual(5, trophiesRepository.get().Count());
        }

        [TestMethod()]
        public void getTest()
        {
            // Act
            Trophy trophy = trophiesRepository.get()[0];

            // Assert
            Assert.AreEqual(trophy.Id, 1);
            Assert.AreEqual(trophy.Competition, "Champions League");
            Assert.AreEqual(trophy.Year, 2020);
        }

        [TestMethod()]
        public void GetByYearTest()
        {
            // Act
            List<Trophy> trophies = trophiesRepository.get(year: 2021);

            // Assert
            Assert.AreEqual(1, trophies.Count());
            Assert.AreEqual(2, trophies[0].Id);
            Assert.AreEqual("La Liga", trophies[0].Competition);
            Assert.AreEqual(2021, trophies[0].Year);
        }

        [TestMethod()]
        public void GetSortByCompetitionTest()
        {
            // Act
            List<Trophy> trophies = trophiesRepository.get(sortby: "competition");

            // Assert
            Assert.AreEqual(5, trophies[0].Id);
            Assert.AreEqual("Bundesliga", trophies[0].Competition);
            Assert.AreEqual(2024, trophies[0].Year);

            Assert.AreEqual(1, trophies[1].Id);
            Assert.AreEqual("Champions League", trophies[1].Competition);
            Assert.AreEqual(2020, trophies[1].Year);

            Assert.AreEqual(4, trophies[4].Id);
            Assert.AreEqual("Serie A", trophies[4].Competition);
            Assert.AreEqual(2023, trophies[4].Year);

        }

        [TestMethod()]
        public void GetSortByYearTest()
        {
            // Act
            List<Trophy> trophies = trophiesRepository.get(sortby: "year");

            // Assert
            Assert.AreEqual(1, trophies[0].Id);
            Assert.AreEqual("Champions League", trophies[0].Competition);
            Assert.AreEqual(2020, trophies[0].Year);

            Assert.AreEqual(2, trophies[1].Id);
            Assert.AreEqual("La Liga", trophies[1].Competition);
            Assert.AreEqual(2021, trophies[1].Year);

            Assert.AreEqual(5, trophies[4].Id);
            Assert.AreEqual("Bundesliga", trophies[4].Competition);
            Assert.AreEqual(2024, trophies[4].Year);
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            // Act
            Trophy trophy = trophiesRepository.GetById(1);

            // Assert
            Assert.AreEqual(1, trophy.Id);
            Assert.AreEqual("Champions League", trophy.Competition);
            Assert.AreEqual(2020, trophy.Year);
        }

        [TestMethod]
        public void GetByIdFailTest()
        {
            // Act
            Trophy trophy = trophiesRepository.GetById(999);

            // Assert
            Assert.IsNull(trophy);
        }

        [TestMethod()]
        public void AddTest()
        {
            // Act
            trophiesRepository.Add(new Trophy(6, "Copa del Rey", 2023));

            // Assert
            Assert.AreEqual(6, trophiesRepository.get().Count());

            Trophy trophy = trophiesRepository.GetById(6);
            Assert.AreEqual(6, trophy.Id);
            Assert.AreEqual("Copa del Rey", trophy.Competition);
            Assert.AreEqual(2023, trophy.Year);
        }

        [TestMethod()]
        public void AddInvalidCompetitionTest()
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => trophiesRepository.Add(new Trophy(6, "", 2023)));
            Assert.ThrowsException<ArgumentException>(() => trophiesRepository.Add(new Trophy(6, "AB", 2023)));
        }

        [TestMethod()]
        public void AddInvalidYearTest()
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => trophiesRepository.Add(new Trophy(6, "Copa del Rey", 1969)));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => trophiesRepository.Add(new Trophy(6, "Copa del Rey", 2026)));
        }

        [TestMethod]
        public void Trophy_InvalidYear_Throws()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => new Trophy(6, "Copa del Rey", 1969));
        }

        [TestMethod()]
        public void AddNullTest()
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => trophiesRepository.Add(null));
        }

        [TestMethod()]
        public void RemoveTest()
        {
            // Act
            trophiesRepository.Remove(1);

            // Assert
            Assert.AreEqual(4, trophiesRepository.get().Count());
        }

        [TestMethod()]
        public void UpdateTest()
        {
            // Arrange
            Trophy newTrophy = new Trophy(10, "DBU pokalen", 2014);

            // Act
            trophiesRepository.Update(2, newTrophy);

            // Assert
            Trophy newtrophyFromRepo = trophiesRepository.GetById(2);
            Assert.AreEqual(2, newtrophyFromRepo.Id);
            Assert.AreEqual("DBU pokalen", newtrophyFromRepo.Competition);
            Assert.AreEqual(2014, newtrophyFromRepo.Year);
        }

        [TestMethod()]
        public void UpdateNotFoundTest()
        {
            // Arrange
            Trophy newTrophy = new Trophy(10, "DBU pokalen", 2014);
            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => trophiesRepository.Update(999, newTrophy));
        }

        [TestMethod()]
        public void UpdateNullTest()
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => trophiesRepository.Update(1, null));
        }
    }
}