using CatalystAssignment.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CatalystAssignment.Repository
{
    public class PersonContext : DbContext
    {
        public PersonContext():base("PersonContext")
        {
            Database.Connection.Close();
            Database.SetInitializer(new PersonContextInitializer());
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
