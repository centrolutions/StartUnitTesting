using Moq;
using NUnit.Framework;
using StarWarsApiCSharp;
using System.Collections.Generic;
using System.Linq;
using TalkingToServices;

namespace TalkingToServicesTests
{
    public class StarWarsTests
    {
        Mock<IRepository<Film>> _FilmRepoMock;
        StarWars _Sut;

        [SetUp]
        public void Setup()
        {
            _FilmRepoMock = new Mock<IRepository<Film>>();
            _Sut = new StarWars(_FilmRepoMock.Object);
        }

        [Test]
        public void GetAllFilms_ReturnsResultsFromService_WhenServiceReturnsResults()
        {
            _FilmRepoMock.Setup(x => x.GetEntities(It.IsAny<int>(), It.IsAny<int>())).Returns(CreateFakeFilmRecords(2).ToList());

            var result = _Sut.GetAllFilms();

            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void GetAllFilms_ReturnsAllResultsFromService_WhenMoreThanOnePageIsAvailable()
        {
            _FilmRepoMock.Setup(x => x.GetEntities(1, 10)).Returns(CreateFakeFilmRecords(10).ToList());
            _FilmRepoMock.Setup(x => x.GetEntities(2, 10)).Returns(CreateFakeFilmRecords(10).ToList());
            _FilmRepoMock.Setup(x => x.GetEntities(3, 10)).Returns(CreateFakeFilmRecords(5).ToList());

            var result = _Sut.GetAllFilms();

            Assert.AreEqual(25, result.Count);
        }

        private IEnumerable<Film> CreateFakeFilmRecords(int count)
        {
            for (var i = 0; i < count; i++)
            {
                yield return new Film() { Title = $"Film {i}" };
            }
        }
    }
}