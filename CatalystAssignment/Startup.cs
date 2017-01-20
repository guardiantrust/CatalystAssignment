using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CatalystAssignment.Startup))]
namespace CatalystAssignment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}
