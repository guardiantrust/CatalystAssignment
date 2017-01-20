using System;

namespace CatalystAssignment.Models
{
    public class PersonViewModel
    {
        private DateTime _dob = DateTime.Now;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }

        public int Age
        {
            get
            {
                if (DOB == new DateTime())
                {
                    return 0;
                }

                DateTime now = DateTime.Today;
                int age = now.Year - DOB.Year;
                if (DOB > now.AddYears(-age)) age--;
                return age;
            }
        }
        public DateTime DOB
        {
            get { return _dob; }
            set
            {
                if (value < new DateTime(1753, 1, 1))
                {
                    //Min datetime for sql
                    _dob = new DateTime(1753, 1, 1);
                }
                else
                {
                    _dob = value;
                }
            }
        }
        public byte[] Picture { get; set; }
        public string Intrests { get; set; }
    }
}