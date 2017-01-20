using CatalystAssignment.Interfaces.Reositories;
using CatalystAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CatalystAssignment.Controllers
{
    public class HomeController : Controller
    {
        private IPersonRepository _personRepo;

        public HomeController(IPersonRepository personRepo)
        {
            _personRepo = personRepo;
        }

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult SearchPerson(string search)
        {
            var persons = _personRepo.SearchByName(search, 0);
            return PartialView(persons.Select(x => ConvertToPersonViewModel(x)));
        }


        public PartialViewResult InsertPerson(PersonViewModel newPerson)
        {

            _personRepo.InsertPerson(ConvertToPerson(newPerson));

            return PartialView();
        }

        private Person ConvertToPerson(PersonViewModel pvm)
        {
            return new Person
            {
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
                }
            };
        }

        private PersonViewModel ConvertToPersonViewModel(Person p)
        {
            return new PersonViewModel
            {
                FirstName = p.FirstName,
                LastName = p.LastName,
                DOB = p.BirthDate,
                Intrests = p.Intrests,
                Picture = p.Picture,
                Address1 = p.Address.Address1,
                Address2 = p.Address.Address2,
                City = p.Address.City,
                State = p.Address.State,
                Zipcode = p.Address.Zipcode
            };


        }
    }
}