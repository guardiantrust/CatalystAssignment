
using CatalystAssignment.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalystAssignment.Interfaces.Reositories
{
    public interface IPersonRepository
    {
        Task<long> InsertPerson(Person person);
        IEnumerable<Person> SearchByName(string search, int threadSleep);
        IEnumerable<Person> GetAllPersons();
    }
}
