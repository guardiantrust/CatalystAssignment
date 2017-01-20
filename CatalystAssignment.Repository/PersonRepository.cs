using CatalystAssignment.Interfaces.Reositories;
using CatalystAssignment.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using CatalystAssignment.Utilities;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace CatalystAssignment.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private PersonContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context to use ffor data</param>
        public PersonRepository(PersonContext context)
        {
            _context = context;
        }

        public IEnumerable<Person> GetAllPersons()
        {
            return _context.Persons.AsNoTracking().Include(x => x.Address).ToList();
        }

        /// <summary>
        /// Insert a new Person
        /// </summary>
        /// <param name="person">Person to insert</param>
        public async Task InsertPerson(Person person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Search for a person by name (first or last)
        /// </summary>
        /// <param name="search">Value to search with</param>
        /// <returns>A collection of Persons</returns>
        public  IEnumerable<Person> SearchByName(string search, int threadSleep = 0)
        {
           
                Thread.Sleep(threadSleep * 1000);

                var strippedString = search.TrimToUpper();
                var query =  _context.Persons
                     .AsNoTracking()
                     .Include(x => x.Address)
                     .Where(x => x.FirstName.Trim().ToUpper().Contains(strippedString)
                     || x.LastName.Trim().ToUpper().Contains(strippedString));

                return query.ToList();
            

      
        }
    }
}
