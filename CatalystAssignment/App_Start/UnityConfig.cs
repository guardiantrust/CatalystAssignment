using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using CatalystAssignment.Interfaces.Reositories;
using CatalystAssignment.Repository;

namespace CatalystAssignment
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
             container.RegisterType<IPersonRepository, PersonRepository>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}