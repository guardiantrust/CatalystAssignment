using CatalystAssignment.Interfaces.Reositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalystAssignment.Models;

namespace CatalystAssignment.Test.Repositories
{
    public class FakePersonRepository : IPersonRepository
    {
        private List<Person> _allPersons = new List<Person>
        {
            new Person {Id=1, FirstName="Ted", LastName="Nuggent" },
            new Person { Id=2,FirstName="Eddie", LastName="Van Halen"},
            new Person { Id = 3,FirstName="Bob", LastName="Marley" }
        };

        public IEnumerable<Person> GetAllPersons()
        {
            return _allPersons;
        }

        public async Task<long> InsertPerson(Person person)
        {
            long id = _allPersons.Max(x => x.Id) + 1;
            person.Id = id;
            _allPersons.Add(person);

            return id;
        }

        public IEnumerable<Person> SearchByName(string search, int threadSleep)
        {
            return _allPersons.Where(x => x.FirstName.ToUpper().Trim().Contains(search.ToUpperInvariant())
            || x.LastName.ToUpper().Trim().Contains(search.ToUpperInvariant())); ;
        }

    }
}
