using System;
using System.ComponentModel.DataAnnotations;

namespace CatalystAssignment.Models
{
    public class PersonViewModel
    {
        private DateTime _dob = DateTime.Now;

        public long Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address1 { get; set; }
        [Required]
        public string Address2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
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
                if (DOB > now.AddYears(-age))
                {
                    age--;
                }

                if (age < 0)
                {
                    age = 0;
                }

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
        [Required]
        public string Intrests { get; set; }
        public string Picture { get; set; }

        public byte[] PictureData { get; set; }
    }
}