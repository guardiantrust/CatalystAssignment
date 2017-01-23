using CatalystAssignment.Models;
using System;
using System.Web;
using System.Web.Mvc;

namespace CatalystAssignment.Controllers
{
    public class BaseController : Controller
    {
        protected Person ConvertToPerson(PersonViewModel pvm)
        {
            return new Person
            {
                Id = pvm.Id,
                FirstName = pvm.FirstName,
                LastName = pvm.LastName,
                BirthDate = pvm.DOB,
                Intrests = pvm.Intrests,
                Address = new Address
                {
                    Address1 = pvm.Address1,
                    Address2 = pvm.Address2,
                    City = pvm.City,
                    State = pvm.State,
                    Zipcode = pvm.Zipcode
                },
                Picture = pvm.PictureData
            };
        }

        protected PersonViewModel ConvertToPersonViewModel(Person p)
        {
            return new PersonViewModel
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                DOB = p.BirthDate,
                Intrests = p.Intrests,
                Address1 = p.Address != null ? p.Address.Address1 : "",
                Address2 = p.Address != null ? p.Address.Address2 : "",
                City = p.Address != null ? p.Address.City : "",
                State = p.Address != null ? p.Address.State : "",
                Zipcode = p.Address != null ? p.Address.Zipcode : "",
                Picture = p.Picture != null ? Convert.ToBase64String(p.Picture) : ""
            }; ;

        }
    }
}