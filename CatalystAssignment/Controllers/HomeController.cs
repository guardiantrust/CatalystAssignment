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
    public class HomeController : BaseController
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

        public JsonResult SearchByName(string search, int threadSleep = 0)
        {
            var persons = _personRepo.SearchByName(search, threadSleep).Select(x => ConvertToPersonViewModel(x));
            return Json(persons, JsonRequestBehavior.AllowGet);
        }

    }
}
