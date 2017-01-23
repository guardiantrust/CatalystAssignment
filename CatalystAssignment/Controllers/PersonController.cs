using CatalystAssignment.Interfaces.Reositories;
using CatalystAssignment.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;

namespace CatalystAssignment.Controllers
{
    public class PersonController : BaseController
    {
        private IPersonRepository _personRepo;

        public PersonController(IPersonRepository personRepo)
        {
            _personRepo = personRepo;
        }
        // GET: Person
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> InsertPerson()
        {
            try
            {
                //Create new PersonViewModel from FormData
                var newPerson = JsonConvert.DeserializeObject<PersonViewModel>(Request.Form["newPerson"]);

                //See if there was a picture attached
                if (Request.Files != null && Request.Files.AllKeys.Contains("picture"))
                {
                    var fileContent = Request.Files["picture"];
                    byte[] fileData = null;
                    using (var binaryReader = new BinaryReader(fileContent.InputStream))
                    {
                        fileData = binaryReader.ReadBytes(fileContent.ContentLength);
                        newPerson.PictureData = fileData;
                    }
                }

                //Get id of the new Person
                var id = await _personRepo.InsertPerson(ConvertToPerson(newPerson));

                //Return new Id
                return Json(id);
            }
            catch
            {
                return Json(-1);
            }
        }

    }
}
