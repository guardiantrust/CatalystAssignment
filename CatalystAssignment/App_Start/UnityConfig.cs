using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using CatalystAssignment.Interfaces.Reositories;
using CatalystAssignment.Repository;
using System.Web;

namespace CatalystAssignment
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IPersonRepository, PersonRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}