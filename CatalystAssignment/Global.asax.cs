using CatalystAssignment.Repository;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CatalystAssignment
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            //Database.SetInitializer(new PersonContextInitializer());
            //using (var db = new PersonContext())
            //{
            //    db.Database.Initialize(false);
            //}
                UnityConfig.RegisterComponents();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
           
            //Database.SetInitializer(new DropCreateDatabaseAlways<PersonContext>());
            //using (var db = new PersonContext())
            //{
            //    db.Persons.Add(new Models.Person { FirstName = "Test", BirthDate = new System.DateTime(2000,1,1), Address = new Models.Address { Address1 = "Test" } });
            //    db.SaveChanges(); 
            //}
        }
    }
}
