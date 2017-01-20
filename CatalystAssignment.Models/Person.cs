
using System;

namespace CatalystAssignment.Models
{
    public class Person
    {
        public long Id { get; set; }
        public virtual Address Address { get; set; }

        public DateTime BirthDate { get; set; }

        public string FirstName { get; set; }

        public string Intrests { get; set; }

        public string LastName { get; set; }

        public byte[] Picture { get; set; }
    }
}
