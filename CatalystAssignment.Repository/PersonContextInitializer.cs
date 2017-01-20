using CatalystAssignment.Models;
using CatalystAssignment.Repository.Properties;
using CatalystAssignment.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;

namespace CatalystAssignment.Repository
{
    public class PersonContextInitializer : DropCreateDatabaseAlways<PersonContext>
    {
        /// <summary>
        /// Insert som some persons to the database to search
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(PersonContext context)
        {
            try
            {
                var persons = new List<Person>
            {
                new Person {FirstName="Al", LastName="Capone", BirthDate= new DateTime(1899, 1,17), Intrests="Baseball", Address = new Address { Address1 = "Cemetary", Address2="Plot 3", City="Provisio Township", State="IL", Zipcode="12345" }, Picture=Resources.alcapone.ImageToByte() },
                new Person {FirstName= "Bugsy", LastName="Siegel", BirthDate=new DateTime(1906, 2, 28), Intrests="Hair balm", Address = new Address { Address1="Cemetary", City="Los Angeles", State="CA", Zipcode="90120" }, Picture=Resources.bugsysiegel.ImageToByte() },
                new Person {FirstName= "Meyer", LastName="Lansky", BirthDate = new DateTime(1902, 7,4), Intrests="Crime Syndicates", Address= new Address {Address1 = "123 Street", Address2 = "Cemetary Lane", City="Miami Beach", State="FL", Zipcode="88445" }, Picture=Resources.meyerlansky.ImageToByte() },
                new Person { FirstName="Albert", LastName="Anastasia", BirthDate=new DateTime(1902, 9, 26), Intrests="Cosa Nostra", Address =new Address{Address1="39 E Rockefeller", Address2="Suite 4", City="New York", State="NY", Zipcode="66888" }, Picture = Resources.albertanastasia.ImageToByte()},
                new Person {FirstName="Sam", LastName="Giancana", BirthDate=new DateTime(1908, 6, 15), Intrests="Cigars", Address=new Address {Address1 = "123 Street", Address2="Appt 3", City="Chicago", State="IL", Zipcode="12345" }, Picture = Resources.samgiancana.ImageToByte() },
                new Person {FirstName= "Micky", LastName="Cohen", BirthDate=new DateTime(1913,9,4), Intrests = "The Family", Address = new Address {Address1="43 Main Street", City="Los Angeles", State="CA", Zipcode="90223" }, Picture = Resources.mickycohen.ImageToByte()}
            };

                persons.ForEach(p => context.Persons.Add(p));
                context.SaveChanges();
            }
            catch
            {
                context.Database.Connection.Close();
                context.Dispose();
            }
        }
    }
}
