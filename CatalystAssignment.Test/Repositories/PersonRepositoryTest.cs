using Microsoft.VisualStudio.TestTools.UnitTesting;
using CatalystAssignment.Repository;
using CatalystAssignment.Interfaces.Reositories;
using System.Linq;
using CatalystAssignment.Test.Properties;
using CatalystAssignment.Utilities;

namespace CatalystAssignment.Test.Repositories
{
    [TestClass]
    public class PersonRepositoryTest
    {
        private PersonContext context = new PersonContext();
        private IPersonRepository repo;

        [TestInitialize]
        public void Setup()
        {
            repo = new FakePersonRepository();
        }

        [TestMethod]
        public void InterfaceMatchesRepositoryTest()
        {
            //Arrange
            PersonRepository personRepo = new PersonRepository(context);

            //Act

            //Assert
            Assert.IsTrue(personRepo is IPersonRepository);
        }

        [TestMethod]
        public void GetAllPersonsTest()
        {
            //Arrange
            var allPersons = repo.GetAllPersons();

            //Act

            //Assert
            Assert.AreEqual(allPersons.Count(), 3);
        }

        [TestMethod]
        public void InsertPersonTest()
        {
            //Arrange
            int startCount = repo.GetAllPersons().Count();
            //Act
            repo.InsertPerson(new Models.Person { FirstName = "Sammy", LastName = "Haggar" });

            //Assert
            Assert.AreEqual(startCount + 1, repo.GetAllPersons().Count());
            Assert.IsTrue(repo.GetAllPersons().Any(x => x.FirstName == "Sammy" && x.LastName == "Haggar"));
        }

        [TestMethod]
        public void SearchByNameTest()
        {
            //Arrange

            //Act
            var persons = repo.SearchByName("d",0);

            //Assert
            Assert.AreEqual(persons.Count(), 2);
            Assert.IsTrue(persons.Any(x => x.FirstName == "Ted"));
            Assert.IsTrue(persons.Any(x => x.FirstName == "Eddie"));
        }
    }
}
